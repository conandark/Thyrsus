using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thyrsus.Shared;
using Thyrsus.Shared.Network;

namespace Thyrsus.Account.Classes.Network.Packets
{
    [Method((ushort)HEADER.HEADER_CA_LOGIN, "CA_LOGIN", MethodAttribute.Packetdirection.PdIn, 55)]
    public class Ca_Login : IPacketIn
    {
        public Int32 Version { get; set; }
        public string Id { get; set; }
        public string Password { get; set; }
        public byte Clienttype { get; set; }

        public void Parse(Shared.PC sender, Packet packet)
        {
            try
            {
                using (var ms = new MemoryStream(packet.Data))
                {
                    using (var br = new BinaryReader(ms))
                    {
                        this.Version = br.ReadInt32();
                        this.Id = br.ReadCString(24);
                        this.Password = br.ReadCString(24);
                        this.Clienttype = br.ReadByte();
                    }
                }

                Logging.Debug(string.Format("{0} {1}\n", this.GetType().Name, Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented)));

                if ((Config.ClientType != -1 && Config.ClientType != Clienttype)
                    || (Config.Version != 0 && Config.Version != Version))
                {
                    sender.PacketQueue.Enqueue(Ac_Refuse_Login.CreateBuilder().SetErrorCode((byte)ErrorCodes.REFUSE_INVALID_VERSION).Build());
                    return;
                }

                using (var nLogin = new nLoginDataContext())
                {
                    var result = nLogin.AuthenticateUser(Id).FirstOrDefault();
                    // account exists check
                    if (result == null)
                    {
                        Logging.Debug("authenticateUser had no result");
                        sender.PacketQueue.Enqueue(Ac_Refuse_Login.CreateBuilder().SetErrorCode((byte)ErrorCodes.REFUSE_INVALID_ID).Build());
                        return;
                    }

                    // wrong password check
                    if (result.Passwd != Password)
                    {
                        Logging.Debug("wrong password");
                        sender.PacketQueue.Enqueue(Ac_Refuse_Login.CreateBuilder().SetErrorCode((byte)ErrorCodes.REFUSE_INVALID_PASSWD).Build());
                        return;
                    }

                    switch (result.isConfirmed)
                    {
                        case 5: // banned
                            Logging.Debug("currently banned (5)");
                            sender.PacketQueue.Enqueue(Ac_Refuse_Login.CreateBuilder().SetErrorCode((byte)ErrorCodes.REFUSE_BLOCK_TEMPORARY).Build());
                            return;

                        case 10: // not confirmed
                            Logging.Debug("account not confirmed (10)");
                            sender.PacketQueue.Enqueue(Ac_Refuse_Login.CreateBuilder().SetErrorCode((byte)ErrorCodes.REFUSE_NOT_CONFIRMED).Build());
                            return;
                    }

                    var genderinfo = nLogin.GetSexInfo(result.AID).FirstOrDefault();
                    if (genderinfo != null)
                    {
                        ((PC)sender).RegNum = genderinfo.RegNum;
                        ((PC)sender).Sex = genderinfo.sex;
                        ((PC)sender).Email = genderinfo.Email;
                        ((PC)sender).Id = Id;

                        var accept = Ac_Accept_Login.CreateBuilder().SetAID(result.AID).SetAuthCode(SessionManager.GetSessionId()).SetGender(genderinfo.sex);
                        var exist = Worker.Singleton.Clients.FirstOrDefault(c => ((PC)c).AcceptPacket.AID == result.AID);
                        if (exist != null)
                        {
                            // last login is still recognized, wait...
                            Logging.Debug("last login is still recognized, wait...");
                            //foreach (var ch in Worker.Singleton.Serverlist)
                            //    ch.PacketQueue.Enqueue(Ah_Disconnect.CreateBuilder().SetAID(result.AID).SetReason(2).Build());

                            sender.PacketQueue.Enqueue(Sc_Notify_Ban.CreateBuilder().SetErrorCode((byte)BanCodes.BAN_INFORMATION_REMAINED).Build());
                            exist.Stop();

                            //using (var cl = new ConnectLogDataContext())
                            //    cl.AddConnectLogWhenLogout(result.AID);

                            Worker.Singleton.Clients.Remove(exist);
                            return;
                        }

                        //using (var cl = new ConnectLogDataContext())
                        //    cl.AddConnectLogWhenLogin(sender.Ip, Id, result.AID, false, true);

                        ((PC)sender).AcceptPacket = accept.Build();
                        sender.PacketQueue.Enqueue(((PC)sender).AcceptPacket);
                        Worker.Singleton.Clients.Add((PC)sender);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.CriticalLog(ex.Message);
            }
        }
    }
}
