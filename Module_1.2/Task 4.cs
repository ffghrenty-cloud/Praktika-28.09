using System;

namespace Tasks
{
    class Task4
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введите K (размер массива): ");
            int k = int.Parse(Console.ReadLine());

            Console.Write("Введите A (нижняя граница): ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Введите B (верхняя граница, не включается): ");
            int b = int.Parse(Console.ReadLine());

            Random random = new Random();
            int[] arr = new int[k];
            for (int i = 0; i < k; i++)
                arr[i] = random.Next(a, b);

            Console.WriteLine("\nИсходный массив:");
            for (int i = 0; i < k; i++)
                Console.Write($"{arr[i],6}");
            Console.WriteLine();

            // Ищем индексы минимума и максимума
            int minIdx = 0, maxIdx = 0;
            for (int i = 1; i < k; i++)
            {
                if (arr[i] < arr[minIdx]) minIdx = i;
                if (arr[i] > arr[maxIdx]) maxIdx = i;
            }

            Console.WriteLine($"\nМинимум: {arr[minIdx]} (индекс {minIdx})");
            Console.WriteLine($"Максимум: {arr[maxIdx]} (индекс {maxIdx})");

            // Определяем границы вывода
            int start = Math.Min(minIdx, maxIdx);
            int end = Math.Max(minIdx, maxIdx);

            Console.WriteLine($"\nЭлементы с {start} по {end} включительно:");
            for (int i = start; i <= end; i++)
                Console.Write($"{arr[i],6}");
            Console.WriteLine();
        }
    }
}