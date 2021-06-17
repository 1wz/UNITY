using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson4
{
    /// <summary>
    /// класс для работы с двумерным массивом
    /// </summary>
    class Arr2
    {
        int[,] a;

        /// <summary>
        /// конструктор , заполняющий массив случайными числами
        /// </summary>
        /// <param name="n">размер первого измерения</param>
        /// <param name="m">размер второго измерения</param>
        public Arr2(int n, int m)
        {
            a = new int[n, m];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = rnd.Next(0, 10);
                }
            }

        }


        /// <summary>
        /// конструктор , заполняющий массив из файла
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="filename"></param>
        public Arr2(int n, int m,string filename)
        {
            a = new int[n, m];
            int[] b= Arr.outLod(filename);
            int l = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (l < b.Length)
                    {
                        a[i, j] = b[l];
                        ++l;
                    }
                    else
                        a[i, j] = 0;

                }
            }

        }

        /// <summary>
        /// возвращает сумму всех элементов массива больше заданного "с"
        /// </summary>
        /// <param name="c">минимальное значение для попадания в сумму</param>
        public int SumMore(int c)
        {
            int s = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                   if(a[i,j]>c) s += a[i, j];
                }
            }
            return s;
        }

        /// <summary>
        /// возвращает сумму всех элементов массива
        /// </summary>
        /// <returns></returns>
        public int Sum()
        {
            return this.SumMore(int.MinValue);
        }

        public void MaxN(out int n,out int m)
        {
            n = 0; m = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] > a[n, m])
                    {
                        n = i;m = j;
                    }
                }
            }
        }

        /// <summary>
        /// выводит двумерный массив в консоль
        /// </summary>
        public void output()
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i,j]+"      ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// свойство для изменения и возвращения элементов массива
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int this[int n,int m]
        {
            get
            {
                return a[n, m];
            }
            set
            {
                a[n, m] = value;
            }
        }

        /// <summary>
        /// возвращает минимальный элемент массива
        /// </summary>
    public int Min
        {
            get
            {
                int m = a[0, 0];
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        if (a[i, j] < m) m = a[i, j];
                    }
                }
                return m;
            }
        }

        /// <summary>
        /// возвращает максимальный элемент массива
        /// </summary>
        public int Max
        {
            get
            {
                int m = a[0, 0];
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        if (a[i, j] > m) m = a[i, j];
                    }
                }
                return m;
            }
        }

    }


}
