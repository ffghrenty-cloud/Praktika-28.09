using System;

namespace EvenOddChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введите целое число: ");
            string input = Console.ReadLine();

            // Пытаемся преобразовать ввод в целое число
            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("Ошибка: нужно ввести целое число.");
                return;
            }

            // Проверка на чётность через остаток от деления на 2
            if (number % 2 == 0)
            {
                Console.WriteLine($"Число {number} — чётное.");
            }
            else
            {
                Console.WriteLine($"Число {number} — нечётное.");
            }
        }
    }
}
