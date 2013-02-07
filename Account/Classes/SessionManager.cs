using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thyrsus.Account.Classes
{
    public class SessionManager
    {
        private static int _sid = 1;

        public static int GetSessionId()
        {
            return _sid++;
        }
    }
}
