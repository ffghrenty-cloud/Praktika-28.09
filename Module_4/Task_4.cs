using System;
using System.Collections.Generic;

// Интерфейс "Книга": любая книга может сообщить доступность и быть выданной/возвращённой
public interface IBook
{
    string Title { get; }        // название
    string Author { get; }       // автор
    bool IsAvailable();          // доступна ли книга
    void Borrow();               // выдать книгу
    void Return();               // вернуть книгу
}

// Обычная книга,можно брать домой
public class RegularBook : IBook
{
    public string Title { get; }
    public string Author { get; }
    private bool available = true;   // по умолчанию книга доступна
    private int pages;

    public RegularBook(string title, string author, int pages)
    {
        Title = title;
        Author = author;
        this.pages = pages;
    }

    public bool IsAvailable() => available;

    public void Borrow()
    {
        if (!available)
            throw new InvalidOperationException($"Книга \"{Title}\" уже выдана");

        available = false;
        Console.WriteLine($"Книга \"{Title}\" выдана.");
    }

    public void Return()
    {
        available = true;
        Console.WriteLine($"Книга \"{Title}\" возвращена.");
    }

    public override string ToString() => $"Обычная книга: \"{Title}\" — {Author} ({pages} стр.)";
}

// Учебник, можно брать только на время занятия
public class Textbook : IBook
{
    public string Title { get; }
    public string Author { get; }
    private bool available = true;
    private string subject;   // предмет

    public Textbook(string title, string author, string subject)
    {
        Title = title;
        Author = author;
        this.subject = subject;
    }

    public bool IsAvailable() => available;

    public void Borrow()
    {
        if (!available)
            throw new InvalidOperationException($"Учебник \"{Title}\" уже выдан");

        available = false;
        Console.WriteLine($"Учебник \"{Title}\" выдан на занятие.");
    }

    public void Return()
    {
        available = true;
        Console.WriteLine($"Учебник \"{Title}\" возвращён.");
    }

    public override string ToString() => $"Учебник: \"{Title}\" — {Author} ({subject})";
}

// Журнал — выдаётся только в читальном зале, домой не выдаётся
public class Magazine : IBook
{
    public string Title { get; }
    public string Author { get; }
    private bool available = true;
    private int issueNumber;   // номер выпуска

    public Magazine(string title, string author, int issueNumber)
    {
        Title = title;
        Author = author;
        this.issueNumber = issueNumber;
    }

    public bool IsAvailable() => available;

    public void Borrow()
    {
        if (!available)
            throw new InvalidOperationException($"Журнал \"{Title}\" уже занят");

        available = false;
        Console.WriteLine($"Журнал \"{Title}\" выдан в читальном зале.");
    }

    public void Return()
    {
        available = true;
        Console.WriteLine($"Журнал \"{Title}\" возвращён.");
    }

    public override string ToString() => $"Журнал: \"{Title}\" — {Author} (выпуск №{issueNumber})";
}

// Редкая книга — выдаётся только по особому разрешению
public class RareBook : IBook
{
    public string Title { get; }
    public string Author { get; }
    private bool available = true;
    private int year;   // год издания

    public RareBook(string title, string author, int year)
    {
        Title = title;
        Author = author;
        this.year = year;
    }

    public bool IsAvailable() => available;

    public void Borrow()
    {
        if (!available)
            throw new InvalidOperationException($"Редкая книга \"{Title}\" уже выдана");

        available = false;
        Console.WriteLine($"Редкая книга \"{Title}\" выдана по особому разрешению.");
    }

    public void Return()
    {
        available = true;
        Console.WriteLine($"Редкая книга \"{Title}\" возвращена.");
    }

    public override string ToString() => $"Редкая книга: \"{Title}\" — {Author} ({year} г.)";
}

public class Program
{
    public static void Main()
    {
        List<IBook> library = new List<IBook>
        {
            new RegularBook("Базовый Питон", "Л.Н. Крутой", 1225),
            new Textbook("ВышМат", "Богпоможет Ю.Н.", "Математика"),
            new Magazine("Жизнь и выживание", "Редколлегия", 5),
            new RareBook("Слово о слове", "Неизвестный автор", 1185)
        };

        Console.WriteLine("Библиотека: начальное состояние\n");

        foreach (IBook b in library)
        {
            Console.WriteLine($"{b}");
            Console.WriteLine($"  Доступна: {(b.IsAvailable() ? "да" : "нет")}\n");
        }

        Console.WriteLine("Выдаём книги\n");

        foreach (IBook b in library)
        {
            try
            {
                b.Borrow();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        Console.WriteLine("\nСостояние после выдачи\n");

        foreach (IBook b in library)
        {
            Console.WriteLine($"{b}");
            Console.WriteLine($"  Доступна: {(b.IsAvailable() ? "да" : "нет")}");
        }

        Console.WriteLine("\nВозвращаем одну книгу\n");

        library[0].Return();   // возвращаем первую книгу

        Console.WriteLine($"\n{library[0]}");
        Console.WriteLine($"  Доступна: {(library[0].IsAvailable() ? "да" : "нет")}");
    }
}