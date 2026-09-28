using System;
using System.Collections.Generic;

namespace Tasks
{
    class Task5
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введите K (размер массива): ");
            int k = int.Parse(Console.ReadLine());

            // Русский алфавит
            string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            // Согласные русского алфавита
            string consonants = "БВГДЖЗЙКЛМНПРСТФХЦЧШЩ";

            Random random = new Random();
            char[] arr = new char[k];
            for (int i = 0; i < k; i++)
                arr[i] = alphabet[random.Next(alphabet.Length)];

            // Формируем массив согласных
            List<char> consonantList = new List<char>();
            foreach (char c in arr)
            {
                if (consonants.IndexOf(c) >= 0)
                    consonantList.Add(c);
            }
            char[] consonantArr = consonantList.ToArray();

            // Вывод
            Console.WriteLine("\nИсходный массив:");
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");
            Console.WriteLine();

            Console.WriteLine("\nМассив согласных:");
            for (int i = 0; i < consonantArr.Length; i++)
                Console.Write($"{consonantArr[i]} ");
            Console.WriteLine();

            Console.WriteLine($"\nКоличество согласных: {consonantArr.Length} из {k}");
        }
    }
}