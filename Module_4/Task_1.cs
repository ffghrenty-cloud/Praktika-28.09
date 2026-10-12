using System;
public interface IFigure
{
    // Метод для вычисления площади
    double Area();

    // Метод для вычисления периметра
    double Perimeter();
}

public class Circle : IFigure
{
    private double radius; // радиус круга

    public Circle(double radius)
    {
        // Радиус должен быть положительным, иначе фигуры не существует
        if (radius <= 0)
            throw new ArgumentException("Радиус должен быть положительным");

        this.radius = radius;
    }

    // Площадь круга
    public double Area()
    {
        return Math.PI * radius * radius;
    }

    // Длина окружности 
    public double Perimeter()
    {
        return 2 * Math.PI * radius;
    }

    // Красивое описание фигуры при печати
    public override string ToString()
    {
        return $"Круг (R={radius})";
    }
}


// Прямоугольник
public class Rectangle : IFigure
{
    private double width;  // ширина
    private double height; // высота

    public Rectangle(double width, double height)
    {
        // Обе стороны должны быть положительными
        if (width <= 0 || height <= 0)
            throw new ArgumentException("Стороны должны быть положительными");

        this.width = width;
        this.height = height;
    }

    // Площадь
    public double Area()
    {
        return width * height;
    }

    // Периметр
    public double Perimeter()
    {
        return 2 * (width + height);
    }

    public override string ToString()
    {
        return $"Прямоугольник ({width} x {height})";
    }
}


// Треугольник
public class Triangle : IFigure
{
    private double a, b, c; // три стороны

    public Triangle(double a, double b, double c)
    {
        // Все стороны должны быть положительными
        if (a <= 0 || b <= 0 || c <= 0)
            throw new ArgumentException("Стороны должны быть положительными");

        // Проверка неравенства треугольника:
        // сумма любых двух сторон должна быть больше третьей,
        // иначе треугольник не сложится
        if (a + b <= c || a + c <= b || b + c <= a)
            throw new ArgumentException("Треугольник с такими сторонами не существует");

        this.a = a;
        this.b = b;
        this.c = c;
    }

    // Площадь по формуле Герона
    public double Area()
    {
        double p = Perimeter() / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    // Периметр
    public double Perimeter()
    {
        return a + b + c;
    }

    public override string ToString()
    {
        return $"Треугольник ({a}, {b}, {c})";
    }
}

public class Program
{
    public static void Main()
    {
        // Создаём разные фигуры и кладём их в общий массив
        IFigure[] figures =
        {
            new Circle(5),        // круг радиуса 5
            new Rectangle(4, 6),  // прямоугольник 4 на 6
            new Triangle(3, 4, 5) // прямоугольный треугольник
        };

        // Благодаря интерфейсу, не важно, что это за фигура — у неё точно есть Area() и Perimeter()
        foreach (IFigure fig in figures)
        {
            Console.WriteLine($"{fig}:");
            Console.WriteLine($"  Площадь:   {fig.Area():F3}");
            Console.WriteLine($"  Периметр:  {fig.Perimeter():F3}");
            Console.WriteLine();
        }
    }
}