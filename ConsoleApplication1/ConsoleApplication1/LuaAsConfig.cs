using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;

namespace CAPI
{
    
    class Chapter25
    {
        public static int MAX_COLOR = 255;
        public static void load(IntPtr L, string fileName, out int w, out int h)
        {
            if (LuaDLL.luaL_loadfile(L, fileName) !=0 || LuaDLL.lua_pcall(L, 0, 0, 0) != 0)
                LuaDLL.luaL_error(L,string.Format("cannot run config. file: {0}",LuaDLL.lua_tostring(L,-1)));
            LuaDLL.lua_getglobal(L, "width");
            LuaDLL.lua_getglobal(L, "height");
            if (!LuaDLL.lua_isnumber(L, -2))
                LuaDLL.luaL_error(L, "width should be a number\n");
            if (!LuaDLL.lua_isnumber(L, -1))
                LuaDLL.luaL_error(L, "Height should be a number\n");
            w = (int)LuaDLL.lua_tonumber(L, -2);
            h = (int)LuaDLL.lua_tonumber(L, -1);

            LuaDLL.lua_getglobal(L, "background");
            if (LuaDLL.lua_istable(L, -1) != 0)
                LuaDLL.luaL_error(L, "background is not a table\n");
            int red = GetField(L, "r");
            int green = GetField(L, "g");
            int blue = GetField(L, "b");
        }

        static int GetField(IntPtr L, string key){
            //LuaDLL.lua_getfield(L,-1,key);
            LuaDLL.lua_pushstring(L, key);
            LuaDLL.lua_gettable(L, -2);
            if (!LuaDLL.lua_isnumber(L, -1))
                LuaDLL.luaL_error(L, "invalid component in background color");
            int result = (int)LuaDLL.lua_tonumber(L, -1) * MAX_COLOR;
            LuaDLL.lua_pop(L, 1);
            return result;
        }
    }
}
