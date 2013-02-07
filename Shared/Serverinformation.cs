using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thyrsus.Shared
{
    public class Serverinformation
    {
        public int ip { get; set; }
        public int port { get; set; }
        public string name { get; set; }
        public ServerTypes type { get; set; }
        public int count { get; set; }
        public int SID { get; set; }
    }
}
