using System;

// Класс Author — информация об авторе
public class Author
{
    public string Name { get; set; }
    public int BirthYear { get; set; }

    public Author(string name, int birthYear)
    {
        Name = name;
        BirthYear = birthYear;
    }

    public void Print()
    {
        Console.WriteLine($"Автор: {Name} (род. {BirthYear})");
    }
}

// Класс Book — композиция: содержит объект Author
public class Book
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public Author Author { get; set; }   // ← композиция

    public Book(string title, int releaseYear, Author author)
    {
        Title = title;
        ReleaseYear = releaseYear;
        Author = author;
    }

    public void Print()
    {
        Console.WriteLine($"Книга: \"{Title}\" ({ReleaseYear} г.)");
        Console.WriteLine($"  {Author.Name}, род. {Author.BirthYear}");
    }
}

class Program
{
    static void Main()
    {
        // Создаём авторов
        Author pushkin = new Author("А. С. Пушкин", 1799);
        Author tolstoy = new Author("Л. Н. Толстой", 1828);
        Author bulgakov = new Author("М. А. Булгаков", 1891);

        // Создаём книги — каждая ссылается на своего автора
        Book[] books =
        {
            new Book("Евгений Онегин",       1833, pushkin),
            new Book("Война и мир",          1869, tolstoy),
            new Book("Мастер и Маргарита",   1967, bulgakov),
            new Book("Анна Каренина",        1877, tolstoy)   // один автор — две книги
        };

        // Вывод информации
        Console.WriteLine("=== Список книг ===\n");
        foreach (Book b in books)
        {
            b.Print();
            Console.WriteLine();
        }

        // Демонстрация: одна и та же ссылка на автора используется в разных книгах
        Console.WriteLine("=== Проверка композиции ===");
        Console.WriteLine($"У книги \"{books[1].Title}\" и \"{books[3].Title}\" " +
                          $"один и тот же автор? " +
                          $"{ReferenceEquals(books[1].Author, books[3].Author)}");
    }
}