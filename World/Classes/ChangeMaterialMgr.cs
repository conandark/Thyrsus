using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;

namespace Thyrsus.World.Classes
{
    public class ChangeMaterialMgr
    {
        public bool Init()
        {
            var lua = new Lua();
            lua.RegisterFunction("InsertRecipe", this, typeof(ChangeMaterialMgr).GetMethod("InsertRecipe"));
            lua.DoFile("data\\ChangeMaterial.lua");
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

        public void InsertRecipe(LuaTable material, LuaTable product, int randomPermill, out bool result, out string msg)
        {
            result = true;
            msg = "";
        }
    }
}
