using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thyrsus.Shared;
using Thyrsus.Shared.Inter;

namespace Thyrsus.Character.Classes
{
    public class Inter : ICharacter
    {
        public bool RegisterServer(int sid, string ip, int port, string name, ServerTypes type)
        {
            throw new NotImplementedException();
        }

        public void Ah_Disconnect(int aid, byte reason)
        {
            throw new NotImplementedException();
        }
    }
}
