using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;

namespace Thyrsus.World.Classes
{
    public class AgitInvestMgr
    {
        public enum Type
        {
            Init = 0,
            Begin = 1,
            End = 2,
            Announce = 3
        }

        public enum Day
        {
            Sun = 0,
            Mon = 1,
            Tue = 2,
            Wed = 3,
            Thu = 4,
            Fri = 5,
            Sat = 6
        }

        public AgitInvestMgr()
        {
            var lua = new Lua();
            lua.RegisterFunction("LoadCycleTBL", this, typeof(AgitInvestMgr).GetMethod("LoadCycleTBL"));
            lua.DoFile("data\\AgitInvest.lua");
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

        public void LoadCycleTBL(int type, int day, int hour, int minute, int second, out bool result, out string msg)
        {
            result = true;
            msg = "";
        }
    }
}
