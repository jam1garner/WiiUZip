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

            for (int i = 0; i < nameCount; i++)
            {
                int length = f.readInt() * 2;
                string name = Encoding.Unicode.GetString(f.readBytes(length));
                f.skip(4);
                int unk1 = f.readInt();
                int unk2 = f.readInt();
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
