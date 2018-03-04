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
            while ( (buff = Console.ReadLine()) != null){
                error = LuaDLL.luaL_loadstring(L, buff) + LuaDLL.lua_pcall(L, 0, 0, 0);
                if (error !=0)
                {
                    Console.WriteLine("error " + LuaDLL.lua_tostring(L, -1));
                    LuaDLL.lua_pop(L, 1);
                }
            }
            LuaDLL.lua_close(L);
            return;
        }
    }
}
