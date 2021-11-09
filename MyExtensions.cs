using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulačka_v2
{
    public static class MyExtensions
    {
        public static string RemoveLast(this string str, int removeChars)
        { 
            // odstraní poslední character ze stringu
            return str.Substring(0, str.Length - removeChars);
        }
    }
}
