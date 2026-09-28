using System;

namespace GuessNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Генерируем случайное число от 1 до 10
            Random random = new Random();
            int secret = random.Next(1, 11);  // 1 включительно, 11 не включительно

            Console.Write("Угадайте число от 1 до 10: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int guess))
            {
                Console.WriteLine("Ошибка: введите целое число.");
                return;
            }

            if (guess == secret)
                Console.WriteLine($"Поздравляю! Вы угадали число {secret}.");
            else
                Console.WriteLine($"Не угадали. Было загадано число {secret}.");
        }
    }
}