using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;

namespace Thyrsus.World.Classes
{
    public class ScriptMobTombInfo
    {
        public ScriptMobTombInfo()
        {
            var lua = new Lua();
            lua.RegisterFunction("SetMobTombInfo", this, typeof(ScriptMobTombInfo).GetMethod("SetMobTombInfo"));
            lua.DoFile("data\\mobTomb.lua");
            LuaFunction f = lua.GetFunction("main");
            if (f != null)
            {
                var functionInfo = f.Call();
                if ((bool)functionInfo[0] == true)
                {

                }
                else
                {
                    throw new ApplicationException(functionInfo[1].ToString());
                }
            }
            f.Dispose();
        }

        public void SetMobTombInfo(string npcName, string dialogMessage1, string dialogMessage2, string dialogMessage3, out bool result)
        {
            result = true;
        }
    }
}
