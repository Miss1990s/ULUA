using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            IntPtr L = LuaDLL.luaL_newstate();
            LuaDLL.luaL_openlibs(L);
            string buff;
            int error;
            while ( !String.IsNullOrWhiteSpace(buff = Console.ReadLine())){
                error = LuaDLL.luaL_loadstring(L, buff) + LuaDLL.lua_pcall(L, 0, 0, 0);
                if (error !=0)
                {
                    Console.WriteLine("error " + LuaDLL.lua_tostring(L, -1));
                    LuaDLL.lua_pop(L, 1);
                }
            }

            LuaDLL.lua_pushboolean(L, true);
            LuaDLL.lua_pushnumber(L, 20);
            LuaDLL.lua_pushnil(L);
            LuaDLL.lua_pushstring(L, "Hello");
            Helper.stackDump(L);
            LuaDLL.lua_pushvalue(L, -4);
            Helper.stackDump(L);
            LuaDLL.lua_replace(L, 3);
            Helper.stackDump(L);
            LuaDLL.lua_settop(L, 6);
            Helper.stackDump(L);
            LuaDLL.lua_remove(L, -3);
            Helper.stackDump(L);
            LuaDLL.lua_settop(L, -5);

            LuaDLL.lua_close(L);
            return;
        }
    }
}
