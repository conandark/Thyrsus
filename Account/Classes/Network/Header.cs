using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thyrsus.Account.Classes.Network
{
    public class Header
    {
        public ushort MethodId { get; set; }

        public int HeaderSize { get; set; }

        public int Size { get; set; }

        public static Header ParseFrom(byte[] data)
        {
            var header = new Header();
            header.MethodId = (ushort)((data[1] << 8) | data[0]);
            header.HeaderSize += 2;

            header.Size = PacketLengthManager.GetPacketLengthForMethodId(header.MethodId);
            if (header.Size == -1)
            {
                header.Size = ((data[3] << 8) | data[2]);
                header.HeaderSize += 2;
            }

            header.Size -= header.HeaderSize;
            return header;
        }
    }
}
