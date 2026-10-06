using System;

public class Employee
{//свойства 
    public string Name { get; set; }
    public int Age { get; set; }
    public string Post { get; set; }
    public double Salary { get; set; }

// конструктор по умолчанию
    public Employee()
    {
        this.Name = "Иван";
        this.Age = 0;
        this.Post = "Сотрудник";
        this.Salary = 0;
    }
    public Employee (string Name, int Age,string Post,double Salary)
    {
        this.Name = Name;
        this.Age = Age;
        this.Post = Post;
        this.Salary = Salary;
    }

//рассчет годовой зп
    public double GetYearSalary()
    {
        return Salary * 12; 
    }
    
//вывод информации
    public void PrintInfo()
    {
        Console.WriteLine($"Имя: {Name}\n Возраст: {Age}\n Должность: {Post}\n " +
                          $"Зарплата: {Salary:F2}");
        Console.WriteLine($"Годовой заработок:{GetYearSalary():F2}");                 
}
}
   class Program
{
    static void Main()
    {
        // Объект через конструктор с параметрами
        Employee e1 = new Employee("Иван Петров", 30, "Программист", 1500);
        e1.PrintInfo();
        Console.WriteLine();

        // Объект через конструктор по умолчанию
        Employee e2 = new Employee(); 
        e2.Name   = "Мария Сидорова";
        e2.Age    = 25;
        e2.Post   = "Дизайнер";
        e2.Salary = 1200;
        e2.PrintInfo();
    }
}