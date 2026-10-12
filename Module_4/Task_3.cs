using System;
using System.Collections.Generic;

// Интерфейс "Студент": любой студент может считать средний балл и сообщать курс
public interface IStudent
{
    string Name { get; }       
    double GetAverageGrade();   // средний балл
    int GetCourse();            // курс
}

// Студент 1 курса
public class FirstYearStudent : IStudent
{
    public string Name { get; }
    private int[] grades;   // оценки
    private string group;   // группа

    public FirstYearStudent(string name, string group, int[] grades)
    {
        Name = name;
        this.group = group;
        this.grades = grades;
    }

    public double GetAverageGrade()
    {
        if (grades.Length == 0) return 0;

        double sum = 0;
        foreach (int g in grades) sum += g;

        return sum / grades.Length;
    }

    public int GetCourse() => 1;

    public override string ToString() => $"1 курс, группа {group}, {Name}";
}

// Студент 2 курса
public class SecondYearStudent : IStudent
{
    public string Name { get; }
    private int[] grades;
    private string group;

    public SecondYearStudent(string name, string group, int[] grades)
    {
        Name = name;
        this.group = group;
        this.grades = grades;
    }

    public double GetAverageGrade()
    {
        if (grades.Length == 0) return 0;

        double sum = 0;
        foreach (int g in grades) sum += g;

        return sum / grades.Length;
    }

    public int GetCourse() => 2;

    public override string ToString() => $"2 курс, группа {group}, {Name}";
}

// Студент 3 курса
public class ThirdYearStudent : IStudent
{
    public string Name { get; }
    private int[] grades;
    private string group;

    public ThirdYearStudent(string name, string group, int[] grades)
    {
        Name = name;
        this.group = group;
        this.grades = grades;
    }

    public double GetAverageGrade()
    {
        if (grades.Length == 0) return 0;

        double sum = 0;
        foreach (int g in grades) sum += g;

        return sum / grades.Length;
    }

    public int GetCourse() => 3;

    public override string ToString() => $"3 курс, группа {group}, {Name}";
}

// Студент 4 курса
public class FourthYearStudent : IStudent
{
    public string Name { get; }
    private int[] grades;
    private string group;

    public FourthYearStudent(string name, string group, int[] grades)
    {
        Name = name;
        this.group = group;
        this.grades = grades;
    }

    public double GetAverageGrade()
    {
        if (grades.Length == 0) return 0;

        double sum = 0;
        foreach (int g in grades) sum += g;

        return sum / grades.Length;
    }

    public int GetCourse() => 4;

    public override string ToString() => $"4 курс, группа {group}, {Name}";
}

public class Program
{
    public static void Main()
    {
        List<IStudent> students = new List<IStudent>
        {
            new FirstYearStudent("Иванов И.И.", "Поис1", new int[] { 7, 2, 3, 7 }),
            new SecondYearStudent("Петров П.П.", "Поис2", new int[] { 9, 9, 2, 7, 6 }),
            new ThirdYearStudent("Сидоров С.С.", "Поис3", new int[] { 10, 9, 7, 8 }),
            new FourthYearStudent("Кузнецова А.А.", "Поис4", new int[] { 9, 5, 8, 8, 7 })
        };

        Console.WriteLine("Учёт студентов\n");

        double totalAvg = 0;

        foreach (IStudent s in students)
        {
            Console.WriteLine($"{s}");
            Console.WriteLine($"  Курс:         {s.GetCourse()}");
            Console.WriteLine($"  Средний балл: {s.GetAverageGrade():F2}\n");

            totalAvg += s.GetAverageGrade();
        }

        Console.WriteLine($"Средний балл по всем: {totalAvg / students.Count:F2}");
    }
}