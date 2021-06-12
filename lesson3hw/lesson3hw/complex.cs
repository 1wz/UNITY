using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson3hw
{/// <summary>
///тип - комплексное число
/// </summary>
    class complex
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
        public complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public complex()
        { }
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
        static public complex sum(complex x,complex y)
        {
            return  new complex(x.Re+y.Re,x.Im+y.Im);
        }

        /// <summary>
        /// возвращает разность двух к.ч.
        /// </summary>
        /// <param name="x">уменьшаемое</param>
        /// <param name="y">вычитаемое</param>
        /// <returns>разность</returns>
        static public complex raz(complex x, complex y)
        {
            return new complex(x.Re - y.Re, x.Im - y.Im);
        }

        /// <summary>
        /// произведение двух к.ч.
        /// </summary>
        /// <param name="x">к.ч</param>
        /// <param name="y">к.ч.</param>
        /// <returns>произведение</returns>
        static public complex pr(complex x, complex y)
        {
            return new complex(x.Re * y.Re-x.Im * y.Im,x.Re*y.Im+x.Im*y.Re);
        }

        public override string ToString()
        {

            return re + (im >= 0 ? "+" : "") + im + "i";

        }
        #endregion
    }
}
