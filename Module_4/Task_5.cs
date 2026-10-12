using System;

// Интерфейс "Рисунок": любой инструмент рисования умеет рисовать
// линии, круги и прямоугольники
public interface IDrawing
{
    void DrawLine(int x1, int y1, int x2, int y2);       // линия
    void DrawCircle(int x, int y, int radius);           // круг
    void DrawRectangle(int x, int y, int width, int height); // прямоугольник
}

// Холст — реализация интерфейса рисования
public class Canvas : IDrawing
{
    private string name;   // имя холста (для вывода)

    public Canvas(string name)
    {
        this.name = name;
    }

    // Рисуем линию: от точки (x1, y1) до точки (x2, y2)
    public void DrawLine(int x1, int y1, int x2, int y2)
    {
        Console.WriteLine($"[{name}] Линия: ({x1},{y1}) → ({x2},{y2})");
    }

    // Рисуем круг: центр (x, y), радиус radius
    public void DrawCircle(int x, int y, int radius)
    {
        if (radius <= 0)
        {
            Console.WriteLine("Ошибка: радиус должен быть положительным");
            return;
        }

        Console.WriteLine($"[{name}] Круг: центр ({x},{y}), R={radius}");
    }

    // Рисуем прямоугольник: левый верхний угол (x, y), ширина и высота
    public void DrawRectangle(int x, int y, int width, int height)
    {
        if (width <= 0 || height <= 0)
        {
            Console.WriteLine("Ошибка: стороны прямоугольника должны быть положительными");
            return;
        }

        Console.WriteLine($"[{name}] Прямоугольник: ({x},{y}), {width}x{height}");
    }

    public override string ToString() => $"Холст \"{name}\"";
}

public class Program
{
    public static void Main()
    {
        // Создаём холст и рисуем на нём через интерфейс
        IDrawing canvas = new Canvas("Основной");

        Console.WriteLine("Рисование на холсте\n");

        canvas.DrawLine(0, 0, 100, 100);
        canvas.DrawLine(100, 0, 0, 100);         // крест-накрест

        canvas.DrawCircle(50, 50, 30);

        canvas.DrawRectangle(10, 10, 80, 60);

        Console.WriteLine("\nПроверка ошибок\n");

        canvas.DrawCircle(0, 0, -5);             // неверный радиус
        canvas.DrawRectangle(0, 0, 0, 10);       // нулевая ширина
    }
}