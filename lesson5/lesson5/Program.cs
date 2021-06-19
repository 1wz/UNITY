using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//Павел Тесленко
namespace lesson5
{
    class Program
    {
        static string text = @"Стандартный класс string позволяет выполнять над строками различные операции, в том числе поиск, замену, вставку и удаление подстрок.";
        static void Main(string[] args)
        {
            #region задача 1 проверка логина
            string login;
                Console.WriteLine("Введите логин от 2 до 10 символов, содержащий только буквы латинского алфавита или цифры, при этом цифра не может быть первой:");
                login = Console.ReadLine();
                Console.WriteLine($"Проверка программой без РВ: {log(login)}       с РВ: {log2(login)}");
                Console.ReadKey();
                Console.Clear();
            #endregion

            #region задача 2 класс Message
            //Вывести только те слова сообщения, которые содержат не более n букв.
            Console.WriteLine("Исходный текст:\n\n" + text);
            Console.WriteLine($"\nВведите n, напечатаются только те слова сообщения, которые содержат не более n букв\n");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Massage.notMoreN(text, n);
            Console.ReadKey();
            Console.Clear();

            //Удалить из сообщения все слова, которые заканчиваются на заданный символ.
            Console.WriteLine("Исходный текст:\n\n" + text);
            Console.WriteLine($"\nВведите символ, в тесте будут удалены все слова, заканчивающиеся на него\n");
            string c = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine(Massage.DelEndOfC(text,c));
            Console.ReadKey();
            Console.Clear();

            // Найти самое длинное слово сообщения.
            // Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
            Console.WriteLine("Введите сообщение:\n");
            Console.WriteLine($"\nСамое длинное слово (слова) сообщения: "+ Massage.Leng(Console.ReadLine()));
            Console.ReadKey();
            Console.Clear();

            //Создать метод, который производит частотный анализ текста. В качестве параметра в него передается массив слов и текст, в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. Здесь требуется использовать класс Dictionary.
            Console.WriteLine("Исходный текст:\n\n" + text);
            Console.WriteLine($"\nВведите через пробел слова, для которых нужно найти частоту\n");
            string[] words = Console.ReadLine().Split(Massage.separators, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine();
            Massage.Chast(text,words);
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region задача 3  Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
            Console.WriteLine("введите первую строку");
            StringBuilder str1 = new StringBuilder(Console.ReadLine());
            Console.WriteLine("введите вторую строку");
            StringBuilder str2 = new StringBuilder(Console.ReadLine());
            if(Perest(str1,str2)) Console.WriteLine("является перестановкой");
            else Console.WriteLine("HE является перестановкой");
            Console.ReadKey();
            #endregion
        }


        #region к первой задаче
        /// <summary>
        /// проверяет соответствие шаблону без РВ
        /// </summary>
        /// <param name="ss">строка для проверки</param>
        /// <returns>тру или фолс соответственно</returns>
        static bool log(string ss)
        {
            if (ss.Length < 2 || ss.Length > 10) return false;
            for (int i = 0; i < ss.Length; i++)
            {
                char s = ss[i];
                if ((s >= 'a' && s <= 'z') || (s >= 'A' && s <= 'Z') || (i == 0 ? false : (s >= '0' && s <= '9')))
                    continue;
                return false;
            } 
            return true;
        }

        /// <summary>
        /// проверяет соответствие шаблону с РВ
        /// </summary>
        /// <param name="ss">строка для проверки</param>
        /// <returns>тру или фолс соответственно</returns>
        static bool log2(string ss)
        {
            Regex myReg = new Regex("^[a-zA-Z]{1}[a-zA-Z0-9]{1,9}$");
            return(myReg.IsMatch(ss));
        }
        #endregion

        #region ко 2 задаче
        /// <summary>
        /// принимает 2 строки и определяет, являются ли они перестановками
        /// </summary>
        /// <param name="s1">1 строка</param>
        /// <param name="s2">2 строка</param>
        /// <returns>тру если являются, фолс - иначе</returns>
        static bool Perest(StringBuilder s1, StringBuilder s2)
        {
            if (s1.Length != s2.Length) return false;
                for(int j=0;j<s2.Length;++j)
                {
                    if(s1[0]==s2[j])
                    {
                        s1.Remove(0, 1);
                        s2.Remove(j, 1);
                    j = -1;
                    }
                }
            if (s1.Length == 0) return true;
            else return false;
        }
        #endregion

    }
}
