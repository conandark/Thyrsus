using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;

namespace Thyrsus.World.Classes
{
    public class MonsterTransformMgr
    {
        public bool LoadLuaFile()
        {
            var lua = new Lua();
            lua.RegisterFunction("InsertTbl", this, typeof(MonsterTransformMgr).GetMethod("InsertTbl"));
            lua.DoFile("data\\MonsterTransform.lua");
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

        public void InsertTbl(string item, string monster, string qualification, out bool result, out string msg)
        {
            result = true;
            msg = "";
        }
    }
}
