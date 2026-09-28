using System;
using System.Collections.Generic;

namespace Tasks
{
    class Task2
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введите предельную сумму S: ");
            int s = int.Parse(Console.ReadLine());

            if (s < 1)
            {
                Console.WriteLine("Ошибка: S должно быть ≥ 1.");
                return;
            }

            Random random = new Random();
            List<int> arr = new List<int>();
            int sum = 0;

            // Добавляем элементы, пока сумма + следующий элемент ≤ S
            while (true)
            {
                int next = random.Next(1, 10);   // 1..9

                if (sum + next > s)
                    break;

                arr.Add(next);
                sum += next;
            }

            Console.WriteLine($"\nСоздан массив из {arr.Count} элементов:");
            Console.WriteLine(string.Join(" ", arr));
            Console.WriteLine($"Сумма элементов: {sum} (≤ {s})");
        }
    }
}