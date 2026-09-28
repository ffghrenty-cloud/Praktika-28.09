using System;

namespace Tasks
{
    class Task3
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введите размер матрицы N: ");
            int n = int.Parse(Console.ReadLine());

            Random random = new Random();
            int[,] matrix = new int[n, n];

            // Заполняем случайными значениями [-50, 50)
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = random.Next(-50, 51);

            Console.WriteLine("\nИсходная матрица:");
            PrintMatrix(matrix);

            // Считаем суммы строк
            int[] sums = new int[n];
            for (int i = 0; i < n; i++)
            {
                int s = 0;
                for (int j = 0; j < n; j++)
                    s += matrix[i, j];
                sums[i] = s;
            }

            Console.WriteLine("\nСуммы строк:");
            for (int i = 0; i < n; i++)
                Console.WriteLine($"  Строка {i}: сумма = {sums[i]}");

            // Сортируем строки по возрастанию суммы
            // Сортировка вставками — меняем местами строки и суммы
            for (int i = 1; i < n; i++)
            {
                int j = i - 1;

                while (j >= 0 && sums[j] > sums[j + 1])
                {
                    // Меняем суммы
                    int tmpSum = sums[j];
                    sums[j] = sums[j + 1];
                    sums[j + 1] = tmpSum;

                    // Меняем строки местами
                    for (int k = 0; k < n; k++)
                    {
                        int tmp = matrix[j, k];
                        matrix[j, k] = matrix[j + 1, k];
                        matrix[j + 1, k] = tmp;
                    }

                    j--;
                }
            }

            Console.WriteLine("\nМатрица после сортировки строк по сумме:");
            PrintMatrix(matrix);

            Console.WriteLine("\nСуммы строк после сортировки:");
            for (int i = 0; i < n; i++)
                Console.WriteLine($"  Строка {i}: сумма = {sums[i]}");
        }

        static void PrintMatrix(int[,] m)
        {
            int rows = m.GetLength(0);
            int cols = m.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write($"{m[i, j],6}");
                Console.WriteLine();
            }
        }
    }
}