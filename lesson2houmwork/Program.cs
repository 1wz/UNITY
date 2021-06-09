using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Тесленко Павел
namespace lesson2houmwork
{   
    class Program
    {
        static string login = "root";
        static string keyword = "GeekBrains";
        static void Main(string[] args)
        {
            int a1, a2, a3,s;
           #region задача 1  наименьшее число
            Console.WriteLine("введите первое число");
            a1=int.Parse(Console.ReadLine());
            Console.WriteLine("введите второе число");
            a2 = int.Parse(Console.ReadLine());
            Console.WriteLine("введите третье число");
            a3 = int.Parse(Console.ReadLine());
            Console.WriteLine($"наименьшее: {(a1<a2?(a1<a3?a1:a3):(a2<a3?a2:a3))}");
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region задача 2 подсчет кол-ва цифр числа
            Console.WriteLine("введите целое число");
            a1 = int.Parse(Console.ReadLine());
            Console.WriteLine($"число {a1} записано из {cifri(a1)} цифр");
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region задача 3 сумма нечетных положительных чисел, пока не введен 0
            s=0;
            do
            {
                Console.WriteLine("введите число");
                a1 = int.Parse(Console.ReadLine());
                if (a1 % 2 != 0 && a1 > 0) s += a1;

            } while (a1 != 0);
            Console.WriteLine($"сумма нечетных положительных: {s}");
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region задача 4 провеока логина и пароля (root ; GeekBrains)
            string log;
            string key;
            a1 = 3;
            do
            {
            Console.WriteLine("введите логин");
            log =Console.ReadLine();
            Console.WriteLine("введите пароль");
            key = Console.ReadLine();
                a1--;
                if (check(log, key)) break;
                else Console.WriteLine($"неверно, попыток осталось: {a1}");
            } while (a1 > 0);
            //if (a1<=0)return;
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region задача 5 индекс массы и рекомендации
            Console.WriteLine("введите ваш рост");
            double h = double.Parse(Console.ReadLine())/100;
            Console.WriteLine("введите ваш вес");
            double  w = double.Parse(Console.ReadLine());
            double ind = w / (h * h);
            if (ind < 25) Console.WriteLine("Ваш вес в норме");
            else if (ind < 29) Console.WriteLine($"Вы имеете избыточный вес. Рекомендуется сбросить {w - 25 * Math.Pow(h, 2):F1} кг");
            else  Console.WriteLine($"У вас ожирение. Рекомендуется сбросить {w - 25 * Math.Pow(h, 2):F1} кг");
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region задача 6 подсчет времени работы программы подсчитывающей "хорошие" числа
            Console.WriteLine("начало работы");
            DateTime start = DateTime.Now;
            s = 0;
            for(int i=1;i<=1000000000;i++)
            {
                if (good(i)) s++;
            }
            Console.WriteLine($"конец работы. кол-во \"хороших\" чисел: {s}. время работы: {DateTime.Now - start}");
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region задача 7 сумма чисел от а до б
            Console.WriteLine("введите a");
            a1 = int.Parse(Console.ReadLine());
            Console.WriteLine("введите b");
            a2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"сумма чисел от a до b равна {sum(a1, a2)}");
            Console.ReadLine();
            #endregion
        }

        static int cifri(int a)
        {
            if (a > 0) return cifri(a/10) + 1;
            else return 0;
        }

        /// <summary>
        /// проверяет верность пароля
        /// </summary>
        /// <param name="log">логин</param>
        /// <param name="key">пароль</param>
        /// <returns></returns>
        static bool check(string log, string key)
        {
            return (log == login && key == keyword);
        }

        /// <summary>
        /// true если число "хорошее"
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        static bool good(int c)
        {
            return c % sum(c) == 0;
        }

        /// <summary>
        /// находит сумму цифр числа
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        static int sum(int c)
        {
            if (c > 0) return sum(c / 10) + c%10;
            else return 0;
        }

        /// <summary>
        /// находит суму чисел от а до б
        /// </summary>
        /// <param name="a">а</param>
        /// <param name="b">б</param>
        /// <returns></returns>
        static int sum(int a, int b)
        {
            if (b < a) return 0;
            else return sum(a, b - 1) + b;
        }
    }
}
