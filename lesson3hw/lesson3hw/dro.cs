using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson3hw
{
    /// <summary>
    /// класс дробей
    /// </summary>
    class dro
    {

        /// <summary>
        /// числитель
        /// </summary>
       int a;
        /// <summary>
        ///знаменатель
        /// </summary>
        int b;

        #region конструктор
        public dro(int a, int b)
        {
            this.a = a;
            if(b!=0)
            this.b = b;
            else 
                throw new Exception("знаменатель не должен равняться нулю");

        }

        public dro()
        { }
        #endregion


        #region свойства
            /// <summary>
            /// числитель
            /// </summary>
        public int A
        {
            get { return a; }
            set { a = value; }
        }
        /// <summary>
        /// знаменатель
        /// </summary>
        public int B
        {
            get { return b; }
            set { 
                if(value!=0)b = value;
                else
                    throw new Exception("знаменатель не должен равняться нулю");
                }
        }
        public double D
        {
            get { return (double)a / b; }
        }
        #endregion

        #region методы
        /// <summary>
        /// возвращает сумму двух дробей
        /// </summary>
        /// <param name="x">дробь</param>
        /// <param name="y">дробь</param>
        /// <returns>дробь</returns>
        static public dro sum(dro x, dro y)
        {
            return new dro(x.A*y.B + y.A*x.B, x.B*y.B);
        }

        /// <summary>
        /// возвращает разность двух дробей.
        /// </summary>
        /// <param name="x">уменьшаемое</param>
        /// <param name="y">вычитаемое</param>
        /// <returns>разность</returns>
        static public dro raz(dro x, dro y)
        {
            return new dro(x.A * y.B - y.A * x.B, x.B * y.B);
        }

        /// <summary>
        /// произведение двух дробей
        /// </summary>
        /// <param name="x">дробь</param>
        /// <param name="y">дробь</param>
        /// <returns>дробь, котора я вляется произведением</returns>
        static public dro pr(dro x, dro y)
        {
            return new dro(x.A * y.A,x.B*y.B);
        }

        /// <summary>
        /// частное двух дробей
        /// </summary>
        /// <param name="x">дробь</param>
        /// <param name="y">дробь</param>
        /// <returns>дробь, котора я вляется частным</returns>
        static public dro ср(dro x, dro y)
        {
            return new dro(x.A * y.B, x.B * y.A);
        }

        /// <summary>
        /// упрощает дробь
        /// </summary>
        /// <param name="x">дробь до</param>
        /// <returns>дробь после</returns>
        static public dro pros(dro x)
        {
            int c = NOD(x.A, x.B);
            return new dro(x.A / c, x.B / c);
        }

        /// <summary>
        /// находит нод
        /// </summary>
        /// <param name="a">целое число</param>
        /// <param name="b">целое число </param>
        /// <returns>целое</returns>
        static int NOD(int a, int b)
        {
            while (a != b)
                if (a > b) a = a - b; else b = b - a;
            return a;
        }


        public override string ToString()
        {

            return A+"/"+B;

        }
        #endregion
    }
}
