using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thyrsus.Account.Classes
{
    public class Config
    {
        public static int ClientType
        {
            get
            {
                try
                {
                    return (int)System.Enum.Parse(typeof(Clienttype), "CLIENTTYPE_" + System.Configuration.ConfigurationManager.AppSettings["Clienttype"]);
                }
                catch
                {
                    return (int)Clienttype.CLIENTTYPE_NONE;
                }
            }
        }

        public static int Version
        {
            get
            {
                try
                {
                    return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Version"]);
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}
