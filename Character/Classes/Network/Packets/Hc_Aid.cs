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
    [Method(0, "HC_AID", MethodAttribute.Packetdirection.PdOut, 0)]
    public class Hc_Aid : IPacketOut
    {
        private static readonly Hc_Aid defaultInstance = new Hc_Aid().MakeReadOnly();

        private Hc_Aid MakeReadOnly()
        {
            return this;
        }

        public static Hc_Aid DefaultInstance
        {
            get { return defaultInstance; }
        }

        public int Aid { get; private set; }

        public void WriteTo(BinaryWriter output)
        {
            output.Write(Aid);
        }

        public sealed partial class Builder
        {
            public Builder()
            {
                result = DefaultInstance;
                resultIsReadOnly = true;
            }

            private bool resultIsReadOnly;
            private Hc_Aid result;

            private Hc_Aid PrepareBuilder()
            {
                if (resultIsReadOnly)
                {
                    Hc_Aid original = result;
                    result = new Hc_Aid();
                    resultIsReadOnly = false;
                    MergeFrom(original);
                }
                return result;
            }

            public Builder MergeFrom(Hc_Aid other)
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

            public Hc_Aid Build()
            {
                return result;
            }
        }

        public static Builder CreateBuilder() { return new Builder(); }
    }
}
