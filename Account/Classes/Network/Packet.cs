using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thyrsus.Account.Classes.Network
{
    public class Packet
    {
        public Header Header {get; set;}
        public byte[] Data {get; set;}
    }
}
