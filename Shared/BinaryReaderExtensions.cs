using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace Thyrsus.Shared
{
    public static class BinaryReaderExtensions
    {
        public static T Read<T>(this BinaryReader br)
        {
            byte[] result = new byte[Marshal.SizeOf(typeof(T))];
            result = br.ReadBytes(result.Length);
            GCHandle handle = GCHandle.Alloc(result, GCHandleType.Pinned);
            var returnObject = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return returnObject;
        }

        public static string ReadCString(this BinaryReader br, int size)
        {
            var i = 0;
            var str = string.Empty;

            for (i = 0; i < size; i++)
            {
                var b = br.ReadByte();
                if (b == 0)
                {
                    break;
                }

                str += (char)b;
            }

            if (i < size)
            {
                br.ReadBytes(size - i - 1);
            }

            return str;
        }
    }
}
