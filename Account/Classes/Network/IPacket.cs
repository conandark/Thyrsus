using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thyrsus.Account.Classes.Network
{
    public interface IPacketIn
    {
        void Parse(PCHandler sender, Packet packet);
    }

    public interface IPacketOut
    {
        void WriteTo(System.IO.BinaryWriter output);
    }
}
