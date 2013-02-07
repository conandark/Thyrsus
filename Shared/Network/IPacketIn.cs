using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thyrsus.Shared.Network
{
    public interface IPacketIn
    {
        void Parse(PC sender, Packet packet);
    }
}
