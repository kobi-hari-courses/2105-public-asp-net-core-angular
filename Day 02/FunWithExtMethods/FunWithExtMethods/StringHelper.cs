using System;
using System.Collections.Generic;
using System.Text;

namespace FunWithExtMethods
{
    public static class StringHelper
    {
        public static string Double(this string src)
        {
            return src + src;
        }

        public static string PadLeft(this string src, int count, char c)
        {
            var length = src.Length;
            var remainder = Math.Max(count - length, 0);

            var pad = new string(c, remainder);
            return pad + src;
        }

        public static string PadRight(this string src, int count, char c)
        {
            var length = src.Length;
            var remainder = Math.Max(count - length, 0);

            var pad = new string(c, remainder);
            return src + pad;
        }
    }
}
