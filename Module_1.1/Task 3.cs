using System;
class Program
{
    // Метод для проверки, является ли строка палиндромом
    static bool IsPalindrome(string input)
    {
        // Проверка на null или пустую строку
        if (string.IsNullOrEmpty(input))
            return true;

        // Удаляем пробелы и приводим к нижнему регистру для корректного сравнения
        string cleaned = input.Replace(" ", "").ToLower();

        // Сравниваем строку с её перевёрнутой версией
        char[] charArray = cleaned.ToCharArray();
        Array.Reverse(charArray);
        string reversed = new string(charArray);

        return cleaned == reversed;
    }
    static void Main()
    {
        Console.Write("Введите строку для проверки на палиндром: ");
        string? text = Console.ReadLine();

        bool result = IsPalindrome(text);

        if (result)
            Console.WriteLine($"Строка \"{text}\" является палиндромом.");
        else
            Console.WriteLine($"Строка \"{text}\" не является палиндромом.");
    }
}