using System;
using System.Collections.Generic;

// Интерфейс "Товар": любой товар может сообщить стоимость и остаток
public interface IProduct
{
    string Name { get; }   
    double GetCost();      // стоимость
    int GetStock();        // остаток на складе
}

// Хлеб — поштучно
public class Bread : IProduct
{
    public string Name { get; }
    private double price;
    private int quantity;

    public Bread(string name, double price, int quantity)
    {
        if (price <= 0) throw new ArgumentException("Цена должна быть положительной");
        if (quantity < 0) throw new ArgumentException("Количество не может быть отрицательным");

        Name = name;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetCost() => price * quantity;
    public int GetStock() => quantity;

    public override string ToString() => $"Хлеб \"{Name}\"";
}

// Молоко(литрами)
public class Milk : IProduct
{
    public string Name { get; }
    private double pricePerLiter;
    private double volume;

    public Milk(string name, double pricePerLiter, double volume)
    {
        if (pricePerLiter <= 0) throw new ArgumentException("Цена должна быть положительной");
        if (volume < 0) throw new ArgumentException("Объём не может быть отрицательным");

        Name = name;
        this.pricePerLiter = pricePerLiter;
        this.volume = volume;
    }

    public double GetCost() => pricePerLiter * volume;
    public int GetStock() => (int)Math.Floor(volume);

    public override string ToString() => $"Молоко \"{Name}\"";
}

// Сыр(вес)
public class Cheese : IProduct
{
    public string Name { get; }
    private double pricePerKg;
    private double weight;

    public Cheese(string name, double pricePerKg, double weight)
    {
        if (pricePerKg <= 0) throw new ArgumentException("Цена должна быть положительной");
        if (weight < 0) throw new ArgumentException("Вес не может быть отрицательным");

        Name = name;
        this.pricePerKg = pricePerKg;
        this.weight = weight;
    }

    public double GetCost() => pricePerKg * weight;
    public int GetStock() => (int)Math.Floor(weight);

    public override string ToString() => $"Сыр \"{Name}\"";
}

// Шоколад — поштучно, со скидкой
public class Chocolate : IProduct
{
    public string Name { get; }
    private double price;
    private int quantity;
    private double discount;

    public Chocolate(string name, double price, int quantity, double discount = 0)
    {
        if (price <= 0) throw new ArgumentException("Цена должна быть положительной");
        if (quantity < 0) throw new ArgumentException("Количество не может быть отрицательным");
        if (discount < 0 || discount >= 1) throw new ArgumentException("Скидка должна быть в диапазоне [0, 1)");

        Name = name;
        this.price = price;
        this.quantity = quantity;
        this.discount = discount;
    }

    public double GetCost() => price * quantity * (1 - discount);
    public int GetStock() => quantity;

    public override string ToString() => $"Шоколад \"{Name}\"";
}

public class Program
{
    public static void Main()
    {
        List<IProduct> products = new List<IProduct>
        {
            new Bread("Хлебный", 35.50, 40),
            new Milk("Свежее", 80.00, 25.5),
            new Cheese("Сырный", 650.00, 3.7),
            new Chocolate("Вкусный", 90.00, 15, 0.10)
        };

        Console.WriteLine("=== Учёт товаров ===\n");

        double total = 0;

        foreach (IProduct p in products)
        {
            Console.WriteLine($"{p}");
            Console.WriteLine($"  Остаток:    {p.GetStock()} ед.");
            Console.WriteLine($"  Стоимость:  {p.GetCost():F2} руб.\n");

            total += p.GetCost();
        }

        Console.WriteLine("------------------------");
        Console.WriteLine($"Итого: {total:F2} руб.");
    }
}