using System;

namespace Tasks
{
    class Task2
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int[] arr = { 5, 12, 3, 18, 7, 1, 9, 14, 2, 6 };

            Console.WriteLine("Исходный массив:");
            Console.WriteLine(string.Join(" ", arr));

            Console.Write("\nВведите целое число для замены максимума: ");
            int replacement = int.Parse(Console.ReadLine());

            // Ищем индекс максимального элемента
            int maxIndex = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > arr[maxIndex])
                    maxIndex = i;
            }

            Console.WriteLine($"Максимальный элемент: {arr[maxIndex]} (индекс {maxIndex})");

            // Заменяем
            arr[maxIndex] = replacement;

            Console.WriteLine("Изменённый массив:");
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}