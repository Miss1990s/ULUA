using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;

namespace ConsoleApplication1
{
    class Helper
    {
        /// <summary>
        /// 遍历打印栈
        /// </summary>
        /// <param name="L"></param>
        public static void stackDump(IntPtr L)
        {
            int i;
            int top = LuaDLL.lua_gettop(L);
            for (i = 1; i < top; i++)
            {
                LuaTypes t = LuaDLL.lua_type(L, i);
                switch (t)
                {
                    case LuaTypes.LUA_TSTRING:
                        {
                            Console.WriteLine("'%s'", LuaDLL.lua_tostring(L, i));
                            break;
                        }
                    case LuaTypes.LUA_TBOOLEAN:
                        {
                            Console.WriteLine("'%s'", LuaDLL.lua_toboolean(L, i));
                            break;
                        }
                    case LuaTypes.LUA_TNUMBER:
                        {
                            Console.WriteLine("'%s'", LuaDLL.lua_tonumber(L, i));
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("'%s'", LuaDLL.luaL_typename(L, t));
                            break;
                        }
                }
                Console.WriteLine("    ");
            }
            Console.WriteLine("\n");
        }
    }
}
