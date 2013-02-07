using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thyrsus.Shared;

namespace Thyrsus.Character.Classes
{
    public class CharacterInfo
    {
        public static void Write(GetCharInfoResult character, BinaryWriter output)
        {
            output.Write(character.GID);
            output.Write(character.exp);
            output.Write(character.money);
            output.Write(character.jobexp);
            output.Write(character.joblevel);
            output.Write(character.bodystate);
            output.Write(character.healthstate);
            output.Write(character.effectstate);
            output.Write(character.virtue);
            output.Write(character.honor);
            output.Write(character.jobpoint);
            output.Write(character.hp);
            output.Write(character.maxhp);
            output.Write(character.sp);
            output.Write(character.maxsp);
            output.Write(character.speed);
            output.Write(character.job);
            output.Write(character.head);
            output.Write(character.weapon);
            output.Write(character.clevel);
            output.Write(character.sppoint);
            output.Write(character.accessory);
            output.Write(character.shield);
            output.Write(character.accessory2);
            output.Write(character.accessory3);
            output.Write(character.headpalette);
            output.Write(character.bodypalette);
            output.WriteCString(character.CharName, 24);
            output.Write(character.STR);
            output.Write(character.AGI);
            output.Write(character.VIT);
            output.Write(character.INT);
            output.Write(character.DEX);
            output.Write(character.LUK);
            output.Write(character.CharNum);
            output.Write(character.haircolor);
            output.Write((short)(character.bIsChangedCharName == true ? 0 : 1));
            output.WriteCString(character.mapname, 16);
            output.Write(character.delrevdate.UnixTime());
            output.Write(character.robepalette);
            output.Write(character.chr_slot_change.Value);
            output.Write(character.chr_name_changeCNT.Value);
        }
    }
}
