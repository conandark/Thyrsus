using System;
using System.IO;
namespace Thyrsus.Shared
{
    public static class BinaryWriterExtensions
    {
        public static void WriteCString(this BinaryWriter bw, string data, int size)
        {
            if (data == null)
                data = string.Empty;
            if (data.Length > size)
                data = data.Substring(0, size);
            if (data.Length < size)
                data = data.PadRight(size, Convert.ToChar("\0"));

            bw.Write(System.Text.Encoding.Default.GetBytes(data));
        }
    }
}
