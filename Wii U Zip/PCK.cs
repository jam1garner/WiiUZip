using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Wii_U_Zip
{
    class PCK
    {
        public struct MineString
        {
            public string name;
            public int unk1;
            public int unk2;
        }

        public List<MineString> mineStrings = new List<MineString>();

        public PCK()
        {

        }

        public PCK(string filename)
        {
            Read(File.ReadAllBytes(filename));
        }

        public void Read(byte[] data)
        {
            FileData f = new FileData(data);
            f.Endian = Endianness.Big;

            int versionNumber = f.readInt();
            int nameCount = f.readInt();
            f.skip(4);
            
            for (int i = 0; i < nameCount; i++)
            {
                MineString temp = new MineString();
                int length = f.readInt() * 2;
                temp.name = Encoding.Unicode.GetString(f.readBytes(length));
                //f.skip(4);
                temp.unk1 = f.readInt();
                temp.unk2 = f.readInt();
                mineStrings.Add(temp);
            }
        }

        public byte[] Rebuild()
        {
            FileOutput f = new FileOutput();
            f.Endian = Endianness.Big;


            return f.getBytes();
        }
    }
}
