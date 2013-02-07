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
    [Method((ushort)HEADER.HEADER_HC_BLOCK_CHARACTER, "HC_BLOCK_CHARACTER", MethodAttribute.Packetdirection.PdOut, 0)]
    public class Hc_Block_Character : IPacketOut
    {
        private static readonly Hc_Block_Character defaultInstance = new Hc_Block_Character().MakeReadOnly();

        private Hc_Block_Character MakeReadOnly()
        {
            return this;
        }

        public static Hc_Block_Character DefaultInstance
        {
            get { return defaultInstance; }
        }

        public void WriteTo(BinaryWriter output)
        {
            output.Write((ushort)HEADER.HEADER_HC_BLOCK_CHARACTER);
            output.Write(Convert.ToInt16(4));
        }

        public sealed partial class Builder
        {
            public Builder()
            {
                result = DefaultInstance;
                resultIsReadOnly = true;
            }

            private bool resultIsReadOnly;
            private Hc_Block_Character result;

            private Hc_Block_Character PrepareBuilder()
            {
                if (resultIsReadOnly)
                {
                    Hc_Block_Character original = result;
                    result = new Hc_Block_Character();
                    resultIsReadOnly = false;
                    MergeFrom(original);
                }
                return result;
            }

            public Builder MergeFrom(Hc_Block_Character other)
            {
                if (other == DefaultInstance) return this;
                PrepareBuilder();
                return this;
            }

            public Hc_Block_Character Build()
            {
                return result;
            }
        }

        public static Builder CreateBuilder() { return new Builder(); }
    }
}