using System;

namespace Tasks
{
    class Task3
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Сколько простых чисел вывести? K = ");
            int k = int.Parse(Console.ReadLine());

            int count = 0;     // сколько простых уже нашли
            int number = 2;    // с какого числа начинаем проверку

            Console.WriteLine($"\nПервые {k} простых чисел:");

            while (count < k)
            {
                if (IsPrime(number))
                {
                    Console.Write($"{number,6}");
                    count++;

                    // Переход на новую строку каждые 10 чисел
                    if (count % 10 == 0)
                        Console.WriteLine();
                }
                number++;
            }

            // Если последняя строка неполная — добавляем перевод строки
            if (count % 10 != 0)
                Console.WriteLine();
        }

        // Проверка: простое ли число
        static bool IsPrime(int n)
        {
            if (n < 2) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            for (int i = 3; i * i <= n; i += 2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }
}