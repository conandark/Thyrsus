using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thyrsus.Shared.Inter
{
    public interface ICharacter
    {
        bool RegisterServer(int sid, string ip, int port, string name, ServerTypes type);
        void Ah_Disconnect(int aid, byte reason);
    }
}
