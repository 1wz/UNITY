using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lesson5
{
    static class Massage
    {
        public static string[] separators = { ",", ".", "!", "?", ";", ":", " " };
        public static void notMoreN(string ss, int n)
        {
            string[] words = ss.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length <= n)
                {
                    Console.Write(words[i]+" ");
                }
            }
        }

        public static string DelEndOfC(string ss, string c)
        {

            ss=Regex.Replace(ss, @"\b{1}\w*" + c + @"\b{1}","");
            return ss;
        }

        public static StringBuilder Leng(string ss)
        {
            StringBuilder max = new StringBuilder();
            string[] words = ss.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > max.Length)
                {
                    max.Length = 0;
                    max.Append(words[i]);
                }
                else if(words[i].Length == max.Length)
                {
                    max.Append(", " + words[i]);
                }
            }
            return max;
        }

        public static void Chast(string ss, string[] slo)
        {
            Dictionary<string, int> openWith =new Dictionary<string, int>();
            string[] words = ss.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in slo)
            {
                openWith.Add(s, 0);
            }
            for (int i = 0; i < words.Length; i++)
            {
                try
                {
                    ++openWith[words[i]];
                }
                catch (KeyNotFoundException)
                {
                }
            }
            foreach(string s in slo)
            {
                Console.WriteLine(s + "    " + openWith[s]);
            }
        }
    }
}
