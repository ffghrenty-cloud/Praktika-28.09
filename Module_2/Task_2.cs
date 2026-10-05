using System;

public class Shape
{
    public virtual double Area()
    {
        return 0;
    }

    public virtual double Perimeter()
    {
        return 0;
    }
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double Area()
    {
        return Width * Height;
    }

    public override double Perimeter()
    {
        return 2 * (Width + Height);
    }
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }

    public override double Perimeter()
    {
        return 2 * Math.PI * Radius;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Выберите фигуру:");
        Console.WriteLine("1. Прямоугольник");
        Console.WriteLine("2. Круг");
        Console.Write("Ваш выбор: ");

        string choice = Console.ReadLine();

        Shape shape = null;

        if (choice == "1")
        {
            Console.Write("Введите ширину: ");
            double width = double.Parse(Console.ReadLine());

            Console.Write("Введите высоту: ");
            double height = double.Parse(Console.ReadLine());

            shape = new Rectangle(width, height);
        }
        else if (choice == "2")
        {
            Console.Write("Введите радиус: ");
            double radius = double.Parse(Console.ReadLine());

            shape = new Circle(radius);
        }
        else
        {
            Console.WriteLine("Некорректный ввод");
            return;
        }

        Console.WriteLine($"Площадь = {shape.Area():F2}");
        Console.WriteLine($"Периметр = {shape.Perimeter():F2}");
    }
}