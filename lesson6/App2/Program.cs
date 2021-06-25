using System;
using System.IO;
using System.Collections.Generic;
//задача 2

namespace DoubleBinary
{
    public delegate double Fun(double x);

    class Program
    {
        /// <summary>
        /// записывает в файл значения переданной ей функции на указанном отрезке
        /// </summary>
        /// <param name="F"></param>
        /// <param name="fileName"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="h"></param>
        public static void SaveFunc(Fun F, string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }

        /// <summary>
        /// считывает из фацйла значения типа double и  возвращает в виде массива
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="min"> возвращает минимум через параметр</param>
        /// <returns></returns>
        public static double[] Load(string fileName,out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            long siz = fs.Length / sizeof(double);
            double[] arr=new double[siz];
            min = bw.ReadDouble();
            arr[0] = min;
            double d;
            for (int i = 1; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                arr[i] = d;
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return arr;
        }
        static void Main(string[] args)
        {
            //саздаем массив пар : делегат - название ф-ии 
            List<KeyValuePair<string, Fun>> list = new List<KeyValuePair<string, Fun>>();
            list.Add(new KeyValuePair<string, Fun>("sin(x)", Math.Sin));
            list.Add(new KeyValuePair<string, Fun>("√x", Math.Sqrt));
            list.Add(new KeyValuePair<string, Fun>("tg(x)", Math.Tan));
            list.Add(new KeyValuePair<string, Fun>("x^2",delegate (double x) { return x * x; }));

            //создаем меню
            Console.WriteLine("Выберите необходимую функцию, введя соответствующюю цифру:");
            int i = 0;
            foreach (KeyValuePair<string, Fun> kvp in list)
            {
                Console.WriteLine($"{kvp.Key}     --------------     {i}");
                ++i;
            }

            try
            {
                i = int.Parse(Console.ReadLine());
                Console.WriteLine($"Вы выбрали \"{list[i].Key}\"");////
            }
            catch(System.FormatException )
            {
                Console.WriteLine("!введено недопустимое значение. Приложение завершено.");
                Console.ReadKey();
                return;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                Console.WriteLine("!введено недопустимое значение. Приложение завершено.");
                Console.ReadKey();
                return;
            }



            Console.WriteLine("Введите начало отрезка:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите конец отрезка:");
            double b = double.Parse(Console.ReadLine());

            double min;
            SaveFunc(list[i].Value,"data.bin", a, b, 0.5);
            Load("data.bin",out min);
            Console.WriteLine("Минимальное значение: {0,8:0.000}", min);
            Console.ReadKey();
        }
    }
}

