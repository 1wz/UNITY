using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//задача 4
namespace Languege
{
    /// <summary>
    /// класс Слово~перевод
    /// </summary>
    public class word
    {
        public string slovo { get; set; }

        public string perevod { get; set; }

        public word() { }

        public word(string slovo, string perevod)
        {
            this.slovo = slovo;
            this.perevod = perevod;
        }

        /// <summary>
        /// метод для вывода
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return slovo+"      ~      "+perevod; 
        }

        int CompareTo(word w)          // Создаем метод для сортировки по алфавиту (не обязателен)
        {
            
                return this.slovo.CompareTo(w.slovo);
        }
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
