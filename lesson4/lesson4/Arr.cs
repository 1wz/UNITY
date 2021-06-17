using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lesson4
{
    /// <summary>
    /// класс с методами для работы с одномерными массивами
    /// </summary>
    static class Arr
    {
        /// <summary>
        /// принимает массив и находит кол-во пар , в которых только одно число делится на 3
        /// </summary>
        /// <param name="a">массив целых чисел</param>
        /// <returns>кол-во</returns>
        public static int Dn3(int[] a)
        {
            int count = 0;
        for(int i =0; i<a.Length-1;i++)
            {
                if ((a[i] % 3 == 0) != (a[i + 1] % 3 == 0))
                    ++count;
            }
            return count;
        }

        /// <summary>
        /// функция возвращающая массив всех целых чисел, которые смогла достать из текстового файла
        /// </summary>
        /// <param name="filename">путь к нужному txt файлу</param>
        /// <returns>массив целых чисел</returns>
        public static int[] outLod(string filename)
        {
                int[] a;
                if (File.Exists(filename))//проверка наличия файла 
                {
                        string ss = File.ReadAllText(filename);//переносит весь файл в строку
                        ss += " ";
                        a = new int[ss.Length];
                        int j = 0;
                        string s="";//одно число
                        for (int i = 0; i < ss.Length; i++)//просматривает каждый символ
                        {
                           try//если символ есть цифра, добавляет его к числу
                           {
                             a[j] = int.Parse(Convert.ToString(ss[i]));
                             s += ss[i];
                           }
                           catch (FormatException e)//если символ - не цифра, добавляет текущее число (если оно есть) к массиву
                           {
                                if (s != "" && s != "-")
                                {
                                    a[j] = int.Parse(s);
                                    ++j;
                                }
                                s = "";
                                if (ss[i] == '-') s +='-';
                           }
                        }
                        //переносит результат в новый массив, размер которого равен количеству чисел
                        int[] b = new int[j];
                        for (int i = 0; i < j; ++i)
                        b[i] = a[i];
                        return b;
                }
                else
                throw new FileNotFoundException();
        }

        public static void output(int[] a)
        {
            for (int i = 0; i < a.Length; ++i)
                Console.Write($"{a[i]} ");
            Console.WriteLine();
        }
    }
}
