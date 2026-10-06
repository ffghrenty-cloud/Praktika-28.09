using System;

// Базовый класс
public abstract class Figure//основание для наследников 
{
    public string Name { get; set; }

    protected Figure(string name)
    {
        Name = name;
    }

    // Абстрактный метод для вычисления площади
    public abstract double Area();

    // Метод для вывода информации о фигуре
    public virtual void Print()
    {
        Console.WriteLine($"{Name}: площадь: {Area():F2}");
    }
}

// Производный класс: Круг
public class Circle : Figure
{
    public double Radius { get; set; }

    public Circle(double radius) : base("Круг")
    {
        Radius = radius;
    }

    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }
}

// Производный класс: Прямоугольник
public class Rectangle : Figure
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height) : base("Прямоугольник")
    {
        Width = width;
        Height = height;
    }

    public override double Area()
    {
        return Width * Height;
    }
}

// Производный класс: Треугольник
public class Triangle : Figure
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public Triangle(double a, double b, double c) : base("Треугольник")
    {
        A = a;
        B = b;
        C = c;
    }

    public override double Area()
    {
        double p = (A + B + C) / 2;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }
}

class Program
{
    // Объявление делегата для вычисления площади
    public delegate double AreaDelegate();

    static void Main()
    {
        // Создание массива фигур
        Figure[] figures = new Figure[]
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Triangle(3, 4, 5)
        };

        Console.WriteLine("Вызов метода через делегат");
        foreach (var figure in figures)
        {
            // Делегат, привязанный к методу конкретной фигуры
            AreaDelegate calculator = figure.Area;

            // Динамический вызов метода через делегат
            double area = calculator();
            Console.WriteLine($"{figure.Name}: площадь = {area:F2}");
        }

        Console.WriteLine("\nВызов метода через интерфейс");
        foreach (var figure in figures)
        {
            figure.Print();
        }
    }
}