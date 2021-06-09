using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Павел Тесленко
namespace lesson1houmwork
{
    class Program
    {
        static void Main(string[] args)
        {
            #region задача1
            Console.WriteLine("введите ваше имя");
            string firstname = Console.ReadLine();
            Console.WriteLine("введите вашу фамилию");
            string secondname = Console.ReadLine();
            Console.WriteLine("введите ваш возраст");
            string age = Console.ReadLine();
            Console.WriteLine("введите ваш рост");
            string hight = Console.ReadLine();
            Console.WriteLine("введите ваш вес");
            string weight = Console.ReadLine();
            Console.WriteLine(firstname + " " + secondname + " " + age + " " + hight + " " + weight);
            Console.WriteLine("{0} {1} {2} {3} {4}", firstname, secondname, age, hight, weight);
            Console.WriteLine($"{firstname} { secondname } { age } { hight} { weight}");
            Console.ReadLine();
            Console.Clear();
            //Console.ReadLine();
            #endregion

            #region задача2
            double w = Convert.ToDouble(weight);
            double h = Convert.ToDouble(hight) / 100;
            Console.WriteLine("индекс массы тела = " + (w / (h * h)));
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region задача3
            Console.WriteLine("введите х1");
            double x1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("введите у1");
            double y1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("введите х2");
            double x2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("введите у2");
            double y2 = Convert.ToDouble(Console.ReadLine());
            rad(x1,x2,y1,y2);
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region задача4
            int a = 100;int b = 18;
            Console.WriteLine($"a={a}   b={b}");
            a = a - b;
            b = b + a;
            a = b - a;
            Console.WriteLine($"a={a}   b={b}");
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region задача5
            Console.WriteLine("введите ваш город");
            string city = Console.ReadLine();
            Console.Clear();
            InMid(firstname,-1);
            InMid(secondname, 0);
            InMid(city, 1);
            Console.ReadLine();
            #endregion



        }

        /// <summary>
        /// находит расстояние между двумя точками
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        static void rad(double x1,double x2,double y1,double y2)
        {
            Console.WriteLine($"расстояние между точками: {Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)):F2}");
        }

        /// <summary>
        /// выводит строку в центр консоли
        /// </summary>
        /// <param name="line">строка</param>
        /// <param name="shift">смещение по высоте от центра</param>        
        static void InMid(string line,int shift)
        {
            Console.SetCursorPosition((int)((Console.WindowWidth-line.Length)/2),(int)( Console.WindowHeight/2+shift));
            Console.Write(line);
        }
    }
}
