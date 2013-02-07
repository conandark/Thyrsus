using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thyrsus.Shared;
using Thyrsus.Shared.Inter;

namespace Thyrsus.Account.Classes
{
    class Inter : IAccount
    {
        public Ah_Logon_Exist Ha_Logon(int aid, int authcode, byte sex, int userCount, int sid, int ip)
        {
            Logging.Debug(string.Format("Ha_Logon {{\n\tAID: {0},\n\tAuthCode: {1},\n\tSex: {2},\n\tUserCount: {3},\n\tSID: {4},\n\tIP: {5}\n}}", aid, authcode, sex, userCount, sid, ip));

            // todo Usercount
            var cs = Worker.Singleton.Serverlist.FirstOrDefault(c => c.SID == sid);
            if (cs.SID != 0)
            {
                cs.count = userCount;
            }

            var x = Worker.Singleton.Clients.FirstOrDefault(c => c.AcceptPacket.AID == aid && c.AcceptPacket.AuthCode == authcode);
            if (x != null)
            {
                return new Ah_Logon_Exist() { Aid = aid, Id = x.Id, Personalnumber = x.RegNum, Email = x.Email, TotalUsingTime = 0 };
            }

            return null;
        }

        public bool RegisterServer(int sid, string ip, int port, string name, ServerTypes type)
        {
            Logging.Debug(string.Format(" {0}{1} {2} {3}", sid.ToString().PadLeft(3),
                              type.ToString().PadLeft(5), ip.PadRight(16), name));
            Worker.Singleton.Serverlist.Add(new Serverinformation() { ip = Helper.IpToInt(ip), port = port, type = type, name = name, count = 0, SID = sid });
            return true;
        }
    }
}
