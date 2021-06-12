using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Павел Тесленко

namespace lesson3hw
{
    class Program
    {
        #region структура 
        /// <summary>
        /// структура "комплексное число"
        /// </summary>
        struct complexstr
        {

            /// <summary>
            /// действительная часть
            /// </summary>
            double re;
            /// <summary>
            /// мнимая часть
            /// </summary>
            double im;

            #region конструктор
            public complexstr(double re, double im)
            {
                this.re = re;
                this.im = im;
            }

          
            #endregion

            #region свойства
            public double Im
            {
                get { return im; }
                set { im = value; }
            }
            public double Re
            {
                get { return re; }
                set { re = value; }
            }
            #endregion

            #region методы
            /// <summary>
            /// возвращает сумму двух к.ч.
            /// </summary>
            /// <param name="x">к.ч</param>
            /// <param name="y">к.ч.</param>
            /// <returns>сумма</returns>
            static public complexstr sum(complexstr x, complexstr y)
            {
                return new complexstr(x.Re + y.Re, x.Im + y.Im);
            }

            /// <summary>
            /// возвращает разность двух к.ч.
            /// </summary>
            /// <param name="x">уменьшаемое</param>
            /// <param name="y">вычитаемое</param>
            /// <returns>разность</returns>
            static public complexstr raz(complexstr x, complexstr y)
            {
                return new complexstr(x.Re - y.Re, x.Im - y.Im);
            }

            /// <summary>
            /// произведение двух к.ч.
            /// </summary>
            /// <param name="x">к.ч</param>
            /// <param name="y">к.ч.</param>
            /// <returns>сумма</returns>
            static public complexstr pr(complexstr x, complexstr y)
            {
                return new complexstr(x.Re * y.Re - x.Im * y.Im, x.Re * y.Im + x.Im * y.Re);
            }

            public override string ToString()
            {

                return re + (im >= 0 ? "+" : "") + im + "i";

            }
            #endregion
            #endregion
        }
        static void Main(string[] args)
        {/*
            #region задача 1 класс с умножением и switch
            complex rez=new complex();
            complex c1 = new complex();
            Console.WriteLine("введите действительную часть первого числа");
            c1.Re = double.Parse(Console.ReadLine());
            Console.WriteLine("введите мнимую часть первого числа");
            c1.Im = double.Parse(Console.ReadLine());
            complex c2 = new complex();
            Console.WriteLine("введите действительную часть второго числа");
            c2.Re = double.Parse(Console.ReadLine());
            Console.WriteLine("введите мнимую часть второго числа");
            c2.Im = double.Parse(Console.ReadLine());
            Console.WriteLine($"первое число: {c1}; второе: {c2}");
            Console.WriteLine("для выплнения действия введите соответствующий символ:");
            Console.WriteLine("сложение - \'+\'\nвычитание - \'-\'\nумножение - \'*\'");
            switch (Console.ReadLine())
            {
                case "+": rez = complex.sum(c1, c2);break;
                case "-": rez = complex.raz(c1, c2);break;
                case "*": rez = complex.pr(c1, c2);break;
                
            }
            
            Console.WriteLine("ответ: "+rez);
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region задача 2 сумма нечетных положительных чисел, пока не введен 0
            int s = 0;
            int a1;
            bool t;
            do
            {
                Console.WriteLine("введите число");
                t=int.TryParse(Console.ReadLine(),out a1);
                while(!t)
                {
                    Console.WriteLine("некорректное число. повторите ввод");
                    t = int.TryParse(Console.ReadLine(), out a1);
                }
                if (a1 % 2 != 0 && a1 > 0) s += a1;

            } while (a1 != 0);
            Console.WriteLine($"сумма нечетных положительных: {s}");
            Console.ReadLine();
            Console.Clear();
            #endregion
*/
            #region задача 3 класс дробей
            dro d1 = new dro();
            dro d2 = new dro();
            dro otv = new dro();
            Console.WriteLine("выберите необходимое действие с дробями, введя соответствующий символ:");
            Console.WriteLine("сложение - \'+\'\nвычитание - \'-\'\nумножение - \'*\'\nделение - \'/\'\nупрощение дроби - \'%\'");
            string sym = Console.ReadLine();
            if(sym=="%")
            {
                Console.WriteLine("введите числитель дроби");
                d1.A = int.Parse(Console.ReadLine());
                Console.WriteLine("введите знаменатель дроби");
                d1.B = int.Parse(Console.ReadLine());
                otv = dro.pros(d1);
            }
            else
            {
                Console.WriteLine("введите числитель первой дроби");
                d1.A = int.Parse(Console.ReadLine());
                Console.WriteLine("введите знаменатель  первой дроби");
                d1.B = int.Parse(Console.ReadLine());
                Console.WriteLine("введите числитель второй дроби");
                d2.A = int.Parse(Console.ReadLine());
                Console.WriteLine("введите знаменатель второй дроби");
                d2.B = int.Parse(Console.ReadLine());
                switch (sym)
                {
                    case "+": otv = dro.sum(d1,d2); break;
                    case "-": otv= dro.raz(d1, d2); break;
                    case "*": otv = dro.pr(d1, d2); break;
                    case "/": otv = dro.ср(d1, d2); break;

                }
            }
            Console.WriteLine($"ответ:   {otv}                     ({otv.D})");
            Console.ReadKey();
            #endregion

        }
    }
}
