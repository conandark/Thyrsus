using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Thyrsus.Shared;
using Thyrsus.Shared.Network;

namespace Thyrsus.Character.Classes.Network.Packets
{
    [Method((ushort)HEADER.HEADER_CH_ENTER, "CH_ENTER", MethodAttribute.Packetdirection.PdIn, 17)]
    public class Ch_Enter : IPacketIn
    {
        public int Aid { get; set; }
        public int Authcode { get; set; }
        public int UserLevel { get; set; }
        public Int16 Clienttype { get; set; }
        public byte Sex { get; set; }

        public void Parse(Shared.PC sender, Packet packet)
        {
            using (var ms = new MemoryStream(packet.Data))
            {
                using (var br = new BinaryReader(ms))
                {
                    Aid = br.ReadInt32();
                    Authcode = br.ReadInt32();
                    UserLevel = br.ReadInt32();
                    Clienttype = br.ReadInt16();
                    Sex = br.ReadByte();
                    ((PC)sender).Aid = Aid;
                }
            }

            Logging.Debug(string.Format("Ch_Enter {{\n\tAID: {0},\n\tAuthCode: {1},\n\tUserLevel: {2},\n\tClienttype: {3},\n\tSex: {4}\n}}", Aid, Authcode, UserLevel, Clienttype, Sex));
            Worker.Singleton.Clients.Add((PC)sender);

            var ipPoint = (IPEndPoint)sender.Socket.RemoteEndPoint;
            using (var account = new Account.AccountClient())
            {
                var ah_logon_exist = account.Ha_Logon(Aid, Authcode, Sex, Worker.Singleton.Clients.Count(), Config.Sid, Helper.IpToInt(ipPoint.Address));
                if (ah_logon_exist != null)
                {
                    sender.Id = ah_logon_exist.Id;
                    sender.Email = ah_logon_exist.Email;
                    sender.PacketQueue.Enqueue(Hc_Aid.CreateBuilder().SetAid(Aid).Build());
                    sender.PacketQueue.Enqueue(Hc_Accept_Enter.CreateBuilder().SetAid(Aid).Build());
                    sender.PacketQueue.Enqueue(Hc_Block_Character.CreateBuilder().Build());
                    sender.PacketQueue.Enqueue(Hc_Second_Password_Login.CreateBuilder().SetAid(Aid).SetSeed(0).SetResult(0).Build());
                }
            }
        }
    }
}
