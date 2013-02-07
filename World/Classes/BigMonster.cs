using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;

namespace Thyrsus.World.Classes
{
    public class BigMonster
    {
        public BigMonster()
        {
            var lua = new Lua();
            lua.RegisterFunction("InsertTable", this, typeof(BigMonster).GetMethod("InsertTable"));
            lua.DoFile("data\\BigMonster.lua");
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

        public void InsertTable(string monsterJob, int radius, out bool result, out string msg)
        {
            result = true;
            msg = "";
        }
    }
}
