using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;

namespace Thyrsus.World.Classes
{
    public class WorldConfigMgr
    {
        public bool Init()
        {
            var lua = new Lua();
            lua.RegisterFunction("SetWorldServerID", this, typeof(WorldConfigMgr).GetMethod("SetWorldServerID"));
            lua.RegisterFunction("SetCharacterCount", this, typeof(WorldConfigMgr).GetMethod("SetCharacterCount"));
            lua.DoFile("data\\World.Config.lua");
            LuaFunction f = lua.GetFunction("main");
            if (f != null)
            {
                var functionInfo = f.Call();
                if ((bool)functionInfo[0] == true)
                {
                    return true;
                }
                else
                {
                    throw new ApplicationException(functionInfo[1].ToString());
                }
            }
            f.Dispose();
            return false;
        }

        public void SetWorldServerID(int serverId)
        {
        }

        public void SetCharacterCount(int characterCount)
        {
        }
    }
}
