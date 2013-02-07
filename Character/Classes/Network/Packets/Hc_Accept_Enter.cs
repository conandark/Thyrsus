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
    [Method((ushort)HEADER.HEADER_HC_ACCEPT_ENTER, "HC_ACCEPT_ENTER", MethodAttribute.Packetdirection.PdOut, 0)]
    public class Hc_Accept_Enter : IPacketOut
    {
        private static readonly Hc_Accept_Enter defaultInstance = new Hc_Accept_Enter().MakeReadOnly();

        private Hc_Accept_Enter MakeReadOnly()
        {
            return this;
        }

        public static Hc_Accept_Enter DefaultInstance
        {
            get { return defaultInstance; }
        }

        public int Aid { get; private set; }

        public void WriteTo(BinaryWriter output)
        {
            using (var db = new characterDataContext())
            {
                var client = Worker.Singleton.Clients.FirstOrDefault(x => x.Aid == Aid);
                if (client != null)
                {
                    client.Characters = db.GetCharInfo(Aid).ToArray();

                    output.Write((ushort)HEADER.HEADER_HC_ACCEPT_ENTER);
                    output.Write(Convert.ToInt16(27 + (client.Characters.Count() * 144)));
                    output.Write((byte)Config.TotalSlotNum);
                    output.Write((byte)Config.PremiumStartSlot);
                    output.Write((byte)Config.PremiumEndSlot);
                    
                    // extension
                    output.Write(1);
                    output.Write(100);
                    output.Write(117440512);
                    output.Write(8);
                    output.Write(0);

                    foreach (var character in client.Characters)
                    {
                        CharacterInfo.Write(character, output);
                    }
                }
            }
        }

        public sealed partial class Builder
        {
            public Builder()
            {
                result = DefaultInstance;
                resultIsReadOnly = true;
            }

            private bool resultIsReadOnly;
            private Hc_Accept_Enter result;

            private Hc_Accept_Enter PrepareBuilder()
            {
                if (resultIsReadOnly)
                {
                    Hc_Accept_Enter original = result;
                    result = new Hc_Accept_Enter();
                    resultIsReadOnly = false;
                    MergeFrom(original);
                }
                return result;
            }

            public Builder MergeFrom(Hc_Accept_Enter other)
            {
                if (other == DefaultInstance) return this;
                PrepareBuilder();
                return this;
            }

            /*
             * Aid
             */
            public int Aid
            {
                get { return result.Aid; }
                set { SetAid(value); }
            }
            public Builder SetAid(int value)
            {
                PrepareBuilder();
                result.Aid = value;
                return this;
            }
            public Builder ClearAid()
            {
                PrepareBuilder();
                result.Aid = 0;
                return this;
            }

            public Hc_Accept_Enter Build()
            {
                return result;
            }
        }

        public static Builder CreateBuilder() { return new Builder(); }
    }
}
