using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;

namespace Thyrsus.World.Classes
{
    public class CookingSystem
    {
        public CookingSystem()
        {
            var lua = new Lua();
            lua.RegisterFunction("InsertCookingInfo", this, typeof(CookingSystem).GetMethod("InsertCookingInfo"));
            lua.DoFile("data\\mkCook.lua");
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

        public void InsertCookingInfo(string bookname, string cookingname, int level, LuaTable material, LuaTable creatingItembyFailed, out bool result, out string msg)
        {
            result = true;
            msg = "";
        }
    }
}
