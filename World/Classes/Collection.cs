using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;

namespace Thyrsus.World.Classes
{
    public class Collection
    {
        public bool LoadLuaFile()
        {
            var lua = new Lua();
            lua.RegisterFunction("InsertTBL", this, typeof(Collection).GetMethod("InsertTBL"));
            lua.DoFile("data\\collection.lua");
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

        public void InsertTBL(string monsterJob, string consumeItem, string createItem1, int random1, string createItem2, int random2, string createItem3, int random3, out bool result, out string msg)
        {
            result = true;
            msg = "";
        }
    }
}
