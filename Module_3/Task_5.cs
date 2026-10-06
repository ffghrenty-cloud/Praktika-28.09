using System;
using System.Collections.Generic;

// Делегат-сортировщик: принимает массив, возвращает отсортированный
public delegate int[] SortMethod(int[] data);

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== Сортировка числовых данных ===");
            Console.WriteLine("1 - Пузырьковая сортировка");
            Console.WriteLine("2 - Быстрая сортировка");
            Console.WriteLine("0 - Выход");
            Console.Write("Выбор метода: ");

            string choice = Console.ReadLine();
            if (choice == "0") break;

            // Выбираем делегат под метод сортировки
            SortMethod sorter = choice switch
            {
                "1" => BubbleSort,
                "2" => QuickSort,
                _   => null
            };

            if (sorter == null)
            {
                Console.WriteLine("Неверный выбор.");
                continue;
            }

            // Ввод массива
            int[] data = InputArray();
            if (data == null) continue;

            Console.WriteLine("\nИсходный массив:");
            PrintArray(data);

            // Вызов сортировки через делегат
            int[] sorted = sorter(data);

            Console.WriteLine("Отсортированный массив:");
            PrintArray(sorted);
        }

        Console.WriteLine("Программа завершена.");
    }

    // Ввод массива с клавиатуры
    static int[] InputArray()
    {
        Console.Write("\nВведите числа через пробел: ");
        string line = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(line))
        {
            Console.WriteLine("Пустой ввод.");
            return null;
        }

        var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var result = new List<int>();

        foreach (var part in parts)
        {
            if (int.TryParse(part, out int number))
                result.Add(number);
            else
                Console.WriteLine($"Пропущено: \"{part}\" — не число.");
        }

        if (result.Count == 0)
        {
            Console.WriteLine("Не удалось прочитать ни одного числа.");
            return null;
        }

        return result.ToArray();
    }

    // Вывод массива
    static void PrintArray(int[] data)
    {
        Console.WriteLine("  " + string.Join(", ", data));
    }

    // 1. Пузырьковая сортировка
    static int[] BubbleSort(int[] data)
    {
        int[] arr = (int[])data.Clone();
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }

        return arr;
    }

    // 2. Быстрая сортировка
    static int[] QuickSort(int[] data)
    {
        int[] arr = (int[])data.Clone();
        QuickSortRecursive(arr, 0, arr.Length - 1);
        return arr;
    }

    static void QuickSortRecursive(int[] arr, int left, int right)
    {
        if (left >= right) return;

        int pivot = arr[(left + right) / 2];
        int i = left, j = right;

        while (i <= j)
        {
            while (arr[i] < pivot) i++;
            while (arr[j] > pivot) j--;

            if (i <= j)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                i++;
                j--;
            }
        }

        QuickSortRecursive(arr, left, j);
        QuickSortRecursive(arr, i, right);
    }
}   // ← эта скобка закрывает class Program