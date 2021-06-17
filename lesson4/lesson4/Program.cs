using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a;

            //задание 2
            Console.WriteLine("задание 2 считать массив из текстового вайла \"TrxtFile1.txt\"");
            a = Arr.outLod(AppDomain.CurrentDomain.BaseDirectory+"TextFile1.txt");
            Arr.output(a);
            Console.WriteLine();

            //задание 1 
            Console.WriteLine("задание 1 кол-во пар этого массива в которых только одно число делится на 3:");
            Console.WriteLine(Arr.Dn3(a));
            Console.ReadKey();
            Console.Clear();

            //задание 5 класс для работы с двумерным массивом
            Console.WriteLine("задание 5 массив считывается из текстового вайла \"TrxtFile2.txt\"");
            Arr2 b = new Arr2(3, 5, AppDomain.CurrentDomain.BaseDirectory + "TextFile2.txt");
            b.output();
            int n, m;
            b.MaxN(out n,out m);
            Console.WriteLine($"максимальный элемент: {b.Max} с индексом[{n},{m}]");
            Console.ReadKey();
        }
    }
}
