using System;
using System.Collections.Generic;
using System.IO;

//задача3
class Student
{
    public string lastName;
    public string firstName;
    public string university;
    public string faculty;
    public int course;
    public string department;
    public int group;
    public string city;
    public int age;
    // Создаем конструктор
    public Student(string firstName, string lastName, string university, string faculty, string department,int age, int course,  int group, string city)
    {
        this.lastName = lastName;
        this.firstName = firstName;
        this.university = university;
        this.faculty = faculty;
        this.department = department;
        this.course = course;
        this.age = age;
        this.group = group;
        this.city = city;
    }
}
class Program
{
    static int MyDelegat(Student st1, Student st2)          // Создаем метод для сравнения по курсу и возрасту
    {
        if (st1.course == st2.course)
            return st1.age.CompareTo(st2.age);
        else
            return st1.course.CompareTo(st2.course);
    }
    static void Main(string[] args)
    {
        int course5 = 0;
        int course6 = 0;
        List<Student> list = new List<Student>();                             // Создаем список студентов
        DateTime dt = DateTime.Now;
        StreamReader sr = new StreamReader("students.csv");
        int[] age = new int[3];
        while (!sr.EndOfStream)
        {
            try
            {
                string[] s = sr.ReadLine().Split(';');
                // Добавляем в список новый экземпляр класса Student
                list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                // Одновременно подсчитываем количество шестикурсников и пятикурсников
                if (list[list.Count - 1].course == 5) course5++; 
                if (list[list.Count - 1].course==6) course6++;
                //счтаем кол-во студентов от 18 до 20 лет
                for(int i=0;i<3;++i)
                {
                    if (list[list.Count - 1].age == i + 18) age[i]++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                // Выход из Main
                if (Console.ReadKey().Key == ConsoleKey.Escape) return;
            }
        }
        sr.Close();
        list.Sort(new Comparison<Student>(MyDelegat));
        Console.WriteLine("Всего студентов:" + list.Count);
        Console.WriteLine("Пятикурсников:{0}", course5);
        Console.WriteLine("Шестикурсников:{0}", course6);
        Console.WriteLine("18илетних:{0}", age[0]);
        Console.WriteLine("19летних:{0}", age[1]);
        Console.WriteLine("20летних:{0}", age[2]);
        foreach (var v in list) Console.WriteLine(v.firstName);
        Console.WriteLine(DateTime.Now - dt);
        Console.ReadKey();
    }
}
