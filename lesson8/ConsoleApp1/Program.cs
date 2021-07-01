using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// С помощью рефлексии выведите все свойства структуры DateTime.
namespace ConsoleApp1
{
    class Program
    {
        static PropertyInfo GetPropertyInfo(object obj, string str)
        {
            return obj.GetType().GetProperty(str);
        }

        static void Main(string[] args)
        {
            DateTime dateTime = new DateTime();
            string[] prop = { "Now","UtcNow","Today","Ticks","Date","Month","Minute","Millisecond","Kind","Hour","DayOfYear",
                "DayOfWeek","Day","Second","TimeOfDay","Year" };
            //dateTime.DayOfWeek
            
            foreach(string s in prop)
            Console.WriteLine(GetPropertyInfo(dateTime, s).GetValue(dateTime, null));
            Console.ReadKey();

        }
    }
}
