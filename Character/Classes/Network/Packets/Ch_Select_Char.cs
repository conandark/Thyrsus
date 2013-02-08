using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thyrsus.Shared;
using Thyrsus.Shared.Network;

namespace Thyrsus.Character.Classes.Network.Packets
{
    [Method((ushort)HEADER.HEADER_CH_SELECT_CHAR, "CH_SELECT_CHAR", MethodAttribute.Packetdirection.PdIn, 3)]
    class Ch_Select_Char : IPacketIn
    {
        public byte CharNum { get; set; }

        public void Parse(Shared.PC sender, Packet packet)
        {
            using (var ms = new MemoryStream(packet.Data))
            using (var br = new BinaryReader(ms))
            {
                CharNum = br.ReadByte();
            }

            Logging.Debug(string.Format("Ch_Select_Char {{\n\tCharNum: {0}\n}}", CharNum));
            var character = ((PC)sender).Characters.FirstOrDefault(x => x.CharNum == CharNum);
            if (character != null)
            {
                var mapserver = Worker.Singleton.Maps.FirstOrDefault(m => m.Key == character.mapname);
                var server = Worker.Singleton.Serverlist.FirstOrDefault(s => s.SID == mapserver.Value);

                sender.PacketQueue.Enqueue(Hc_Notify_Zonesvr.CreateBuilder().SetGid(character.GID).SetMapname(character.mapname).SetIp(server.ip).SetPort(server.port).Build());
            }
        }
    }
}
