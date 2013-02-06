﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thyrsus.Account.Classes.Network
{
    public class PacketLengthManager
    {
        public static int GetPacketLengthForMethodId(ushort methodId)
        {
            return Method.GetSize(methodId);
        }
    }
}
