using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Thyrsus.Shared
{
    public class Helper
    {
        public static int IpToInt(string address)
        {
            System.Net.IPAddress ip = null;
            if (System.Net.IPAddress.TryParse(address.Trim(), out ip))
            {
                return BitConverter.ToInt32(ip.GetAddressBytes(), 0);
            }
            else
            {
                return 0;
            }
        }

        public static string IntToIp(int ip)
        {
            return new IPAddress(BitConverter.GetBytes(ip)).ToString();
        }
    }
}
