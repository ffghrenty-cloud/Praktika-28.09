using System;

// Интерфейс — контракт: "умею рисоваться"
public interface IDrawable
{
    void Draw();
}

// Круг
public class Circle : IDrawable
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public void Draw()
    {
        Console.WriteLine($"Рисую круг: радиус = {Radius}, " +
                          $"площадь = {Math.PI * Radius * Radius:F2}");
    }
}

// Прямоугольник
public class Rectangle : IDrawable
{
    public double Width  { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width  = width;
        Height = height;
    }

    public void Draw()
    {
        Console.WriteLine($"Рисую прямоугольник: {Width} x {Height}, " +
                          $"площадь = {Width * Height:F2}");
    }
}

// Треугольник
public class Triangle : IDrawable
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public void Draw()
    {
        double p = (A + B + C) / 2;                        // полупериметр
        double area = Math.Sqrt(p * (p - A) * (p - B) * (p - C)); // формула Герона
        Console.WriteLine($"Рисую треугольник: стороны {A}, {B}, {C}, " +
                          $"площадь = {area:F2}");
    }
}

class Program
{
    static void Main()
    {
        // Массив объектов, реализующих интерфейс IDrawable
        IDrawable[] shapes =
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Triangle(3, 4, 5),
            new Circle(1.5),
            new Rectangle(10, 2),
            new Triangle(6, 6, 6)
        };

        Console.WriteLine("=== Рисуем все фигуры ===\n");

        foreach (IDrawable shape in shapes)
        {
            shape.Draw();   // полиморфизм: у каждого своя реализация
        }
    }
}