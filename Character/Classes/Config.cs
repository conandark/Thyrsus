using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thyrsus.Character.Classes
{
    public class Config
    {
        public static int Sid
        {
            get
            {
                try
                {
                    return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Sid"].ToString());
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static int TotalSlotNum
        {
            get
            {
                try
                {
                    return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["TotalSlotNum"].ToString());
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static int PremiumStartSlot
        {
            get
            {
                try
                {
                    return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PremiumStartSlot"].ToString());
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static int PremiumEndSlot
        {
            get
            {
                try
                {
                    return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PremiumEndSlot"].ToString());
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}
