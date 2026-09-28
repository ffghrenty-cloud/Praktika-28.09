using System;

namespace Tasks
{
    class Task1
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введите размер массива N: ");
            int n = int.Parse(Console.ReadLine());

            double[] arr = new double[n];
            Console.WriteLine("Введите элементы массива:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"  arr[{i}] = ");
                arr[i] = double.Parse(Console.ReadLine());
            }

            // Ищем максимальный по модулю элемент
            double maxAbs = Math.Abs(arr[0]);
            for (int i = 1; i < n; i++)
            {
                if (Math.Abs(arr[i]) > maxAbs)
                    maxAbs = Math.Abs(arr[i]);
            }

            // Нормируем: делим каждый элемент на maxAbs
            Console.WriteLine($"\nМаксимальный по модулю элемент: {maxAbs}");
            Console.WriteLine("Нормированный массив:");
            for (int i = 0; i < n; i++)
            {
                arr[i] /= maxAbs;
                Console.WriteLine($"  arr[{i}] = {arr[i]:F4}");
            }
        }
    }
}