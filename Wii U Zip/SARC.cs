using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Wii_U_Zip
{
    class SARC
    {
        public Dictionary<string, byte[]> files = new Dictionary<string, byte[]>();

        public Endianness endian = Endianness.Big;
        public int padding = -1;

        struct SFATNode
        {
            public int nameHash;
            public int nameTableOffset;
            public int fileDataOffset;
            public int endFileDataOffset;
            public bool hasString;
        }

        public SARC()
        {

        }

        public SARC(string filename)
        {
            Read(File.ReadAllBytes(filename));
        }

        public void Read(byte[] file)
        {
            //Debug ONLY!
            //File.WriteAllBytes("test.sarc", file);
            FileData f = new FileData(file);
            f.Endian = Endianness.Big;
            f.seek(6); //SARC
            int endnss = f.readShort();
            if (endnss == 0xFEFF)
                f.Endian = Endianness.Big;
            if (endnss == 0xFFFE)
                f.Endian = Endianness.Little;

            endian = f.Endian;

            int archiveSize = f.readInt();
            int startOffset = f.readInt();
            padding = startOffset;
            f.skip(10);//SFAT
            int nodeCount = f.readShort();
            int hashMultiplier = f.readInt();

            List<SFATNode> sfatNodes = new List<SFATNode>();
            for (int i = 0; i < nodeCount; i++)
            {
                SFATNode temp;
                temp.nameHash = f.readInt();
                temp.nameTableOffset = f.readInt() - 0x1000000;
                if (temp.nameTableOffset == -0x1000000)
                    temp.hasString = false;
                else
                    temp.hasString = true;
                temp.fileDataOffset = f.readInt();
                temp.endFileDataOffset = f.readInt();
                sfatNodes.Add(temp);
            }

            f.skip(8);//53 46 4E 54 00 08 00 00 SFNT is dumb

            int nameTableStart = f.pos();
            foreach (SFATNode sfat in sfatNodes)
            {
                string tempName;
                if (sfat.hasString) {
                    f.seek(sfat.nameTableOffset * 4 + nameTableStart);
                     tempName = f.readString();
                }
                else
                     tempName = "0x" + sfat.nameHash.ToString("X8");
                f.seek(sfat.fileDataOffset + startOffset);
                byte[] tempFile = f.read(sfat.endFileDataOffset - sfat.fileDataOffset);
                files.Add(tempName, tempFile);
            }
        }

        uint GetHash(char[] name, int length, uint multiplier)
        {
            uint result = 0;
            for (int i = 0; i < length; i++)
            {
                result = name[i] + result * multiplier;
            }
            return result;
        }

        int GetSizeInChunks(int length, int chunkSize)
        {
            int i = length;
            while (i % 4 != 0)
                i++;
            return i;
        }

        private int sfatStartOffset;

        private byte[] RebuildSFATArchive()
        {
            FileOutput f = new FileOutput();
            f.Endian = endian;

            f.writeString("SFAT");
            f.writeShort(0xC);
            f.writeShort(files.Count);
            f.writeInt(0x65);

            int stringPos = 0;
            int dataPos = 0;
            bool isString = true;
            foreach (string filename in files.Keys)
            {
                if (filename.Contains("0x"))
                {
                    isString = false;
                    f.writeInt((int)Convert.ToInt32(filename,16));
                    f.writeInt(0);
                }
                else { 
                f.writeInt((int)GetHash(filename.ToArray(), filename.Length, 0x65));
                f.writeInt(stringPos + 0x1000000);
                    stringPos += GetSizeInChunks(filename.Length + 1, 4) / 4;
                }
                f.writeInt(dataPos);
                f.writeInt(dataPos + files[filename].Length);
                dataPos += files[filename].Length % padding == 0 ? files[filename].Length : files[filename].Length + (padding - files[filename].Length % padding);
            }

            f.writeHex("53464E5400080000");
            if (isString) { 
            foreach (string filename in files.Keys)
            {
                f.writeString(filename);
                f.writeByte(0);
                while (f.pos() % 4 != 0)
                    f.writeByte(0);
            }
            }
            if (padding == -1 || padding < f.pos())
                while ((f.pos() + 0x14) % 0x100 != 0)
                    f.writeByte(0);
            else
                f.writeBytes(new byte[padding - (f.pos() + 0x14)]);

            sfatStartOffset = f.pos();
            int cur = 0;
            foreach (string filename in files.Keys)
            {
                f.writeIntAt(f.pos() - sfatStartOffset , 0x14 + (cur*0x10));
                f.writeBytes(files[filename]);
                f.writeIntAt(f.pos() - sfatStartOffset, 0x18 + (cur * 0x10));
                while ((f.pos() + 0x14) % padding != 0)
                    f.writeByte(0);
                
                cur++;
            }

            return f.getBytes();
        }

        public byte[] Rebuild()
        {
            FileOutput f = new FileOutput();
            f.Endian = endian;

            f.writeString("SARC");
            f.writeShort(0x14);
            f.Endian = endian;
            f.writeShort(65279);

            byte[] sfat = RebuildSFATArchive();

            f.writeInt(sfat.Length + 0x14);
            f.writeInt(sfatStartOffset + 0x14);
            f.writeInt(0x1000000);
            f.writeBytes(sfat);

            return f.getBytes();
        }  
    }
}
