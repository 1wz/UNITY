using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lesson5
{
    /// <summary>
    /// класс к задаче 2
    /// </summary>
    static class Massage
    {
        public static string[] separators = { ",", ".", "!", "?", ";", ":", " " };

        /// <summary>
        /// выводит слова длинна которых не больше п
        /// </summary>
        /// <param name="ss">исходное сообщение</param>
        /// <param name="n">макс длина слов</param>
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

        /// <summary>
        /// удаляет слова заканчивающиеся на переданный символ
        /// </summary>
        /// <param name="ss">исходное сообщение</param>
        /// <param name="c">символ</param>
        /// <returns>обработанное сообщение</returns>
        public static string DelEndOfC(string ss, string c)
        {

            ss=Regex.Replace(ss, @"\b{1}\w*" + c + @"\b{1}","");
            return ss;
        }

        /// <summary>
        /// ищет самое длинное слово в сообщении или несколько( если длина одинаковая)
        /// </summary>
        /// <param name="ss">сообщение</param>
        /// <returns>изм. строка с длинными словами</returns>
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

        /// <summary>
        /// считает и выводит частоту встречи слов в тексте
        /// </summary>
        /// <param name="ss">текст</param>
        /// <param name="slo">массив слов для которых считать частоту</param>
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
