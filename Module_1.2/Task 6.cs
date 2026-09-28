using System;

namespace Tasks
{
    class Task6
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            const int n = 10;
            double[] arr = new double[n];
            Random random = new Random();

            for (int i = 0; i < n; i++)
                arr[i] = random.NextDouble() * 20 - 10;   // [-10, 10)

            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < n; i++)
                Console.WriteLine($"  arr[{i}] = {arr[i],8:F4}");

            // Создаём массив индексов 0..n-1
            int[] indices = new int[n];
            for (int i = 0; i < n; i++)
                indices[i] = i;

            // Сортируем индексы по значениям arr[indices[i]]
            // Простая сортировка вставками
            for (int i = 1; i < n; i++)
            {
                int key = indices[i];
                int j = i - 1;
                while (j >= 0 && arr[indices[j]] > arr[key])
                {
                    indices[j + 1] = indices[j];
                    j--;
                }
                indices[j + 1] = key;
            }

            Console.WriteLine("\nИндексы в порядке возрастания значений:");
            for (int i = 0; i < n; i++)
                Console.WriteLine($"  arr[{indices[i]}] = {arr[indices[i]],8:F4}");
        }
    }
}