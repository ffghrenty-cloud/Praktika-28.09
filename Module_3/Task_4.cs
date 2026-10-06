using System;
using System.Collections.Generic;
using System.Linq;

// Модель данных — книга
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }

    public override string ToString()
    {
        return $"{Title} — {Author} ({Year}, {Genre})";
    }
}

// Делегат-фильтр: принимает книгу, возвращает true, если подходит
public delegate bool BookFilter(Book book);

class Program
{
    static void Main()
    {
        // Список книг русской литературы
        var books = new List<Book>
        {
            new Book { Title = "Преступление и наказание", Author = "Достоевский", Genre = "Роман",          Year = 1866 },
            new Book { Title = "Война и мир",              Author = "Толстой",     Genre = "Роман",          Year = 1869 },
            new Book { Title = "Анна Каренина",            Author = "Толстой",     Genre = "Роман",          Year = 1877 },
            new Book { Title = "Мёртвые души",             Author = "Гоголь",      Genre = "Поэма",          Year = 1842 },
            new Book { Title = "Отцы и дети",              Author = "Тургенев",    Genre = "Роман",          Year = 1862 },
            new Book { Title = "Герой нашего времени",     Author = "Лермонтов",   Genre = "Роман",          Year = 1840 },
            new Book { Title = "Евгений Онегин",           Author = "Пушкин",      Genre = "Роман в стихах", Year = 1833 },
            new Book { Title = "Тихий Дон",                Author = "Шолохов",     Genre = "Роман",          Year = 1940 },
            new Book { Title = "Мастер и Маргарита",       Author = "Булгаков",    Genre = "Роман",          Year = 1967 },
            new Book { Title = "Собачье сердце",           Author = "Булгаков",    Genre = "Повесть",        Year = 1925 }
        };

        while (true)
        {
            Console.WriteLine("\n=== Фильтр книг ===");
            Console.WriteLine("1 - По автору");
            Console.WriteLine("2 - По жанру");
            Console.WriteLine("3 - По году (не раньше)");
            Console.WriteLine("4 - По ключевому слову в названии");
            Console.WriteLine("0 - Выход");
            Console.Write("Выбор: ");

            string choice = Console.ReadLine();
            if (choice == "0") break;

            BookFilter filter = null;

            switch (choice)
            {
                case "1":
                {
                    var authors = books.Select(b => b.Author).Distinct().OrderBy(a => a).ToList();
                    string author = ChooseFromList("автора", authors);
                    if (author == null) break;
                    filter = b => b.Author == author;
                    break;
                }
                case "2":
                {
                    var genres = books.Select(b => b.Genre).Distinct().OrderBy(g => g).ToList();
                    string genre = ChooseFromList("жанр", genres);
                    if (genre == null) break;
                    filter = b => b.Genre == genre;
                    break;
                }
                case "3":
                {
                    var years = books.Select(b => b.Year).Distinct().OrderBy(y => y)
                                     .Select(y => y.ToString()).ToList();
                    string yearStr = ChooseFromList("год", years);
                    if (yearStr == null) break;
                    int year = int.Parse(yearStr);
                    filter = b => b.Year >= year;
                    break;
                }
                case "4":
                {
                    var words = books
                        .SelectMany(b => b.Title.Split(' '))
                        .Where(w => w.Length > 2)
                        .Distinct()
                        .OrderBy(w => w)
                        .ToList();
                    string word = ChooseFromList("слово", words);
                    if (word == null) break;
                    filter = b => b.Title.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0;
                    break;
                }
                default:
                    Console.WriteLine("Неверный выбор.");
                    continue;
            }

            if (filter == null) continue;

            var result = books.Where(b => filter(b)).ToList();
            Print(result);
        }

        Console.WriteLine("Программа завершена.");
    }

    // Универсальный выбор из списка
    static string ChooseFromList(string what, List<string> options)
    {
        Console.WriteLine($"\nВыберите {what}:");
        for (int i = 0; i < options.Count; i++)
            Console.WriteLine($"  {i + 1} - {options[i]}");
        Console.WriteLine("  0 - Назад");
        Console.Write("Выбор: ");

        if (int.TryParse(Console.ReadLine(), out int index)
            && index >= 1 && index <= options.Count)
            return options[index - 1];

        return null;
    }

    // Вывод результата
    static void Print(List<Book> books)
    {
        if (books.Count == 0)
        {
            Console.WriteLine("\nНичего не найдено.");
            return;
        }

        Console.WriteLine($"\nНайдено книг: {books.Count}");
        foreach (var b in books)
            Console.WriteLine("  " + b);
    }
}