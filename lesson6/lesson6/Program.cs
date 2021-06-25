using System;
//задание 1

//создаем делегат
public delegate double Fun(double a,double x);

class Program
{
    // Создаем метод, который принимает делегат
    public static void Table(Fun F,double a, double x, double b)
    {
        Console.WriteLine("----- X ----- Y -----");
        while (x <= b)
        {
            Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(a,x));
            x += 1;
        }
        Console.WriteLine("---------------------");
    }

    // Создаем метод для передачи его в качестве параметра в Table
    public static double Sqr(double a,double x)
    {
        return a * Math.Pow(x, 2);
    }


    // Создаем метод для передачи его в качестве параметра в Table
    public static double Sin(double a, double x)
    {
        return a * Math.Sin(x);
    }

    static void Main()
    {
        Console.WriteLine("Таблица функции a*x^2:");
        Table(new Fun(Sqr),1, -2, 2);
        Fun d = new Fun(Sin);
        Console.WriteLine("Таблица функции a*sin(x):");
        Table(d, 1, -2, 2);
        Console.ReadKey();
    }
}
