using System;

namespace Tasks
{
    class Task1
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Сокращение обыкновенной дроби");

            Console.Write("Введите числитель (≥ 0): ");
            int numerator = int.Parse(Console.ReadLine());

            Console.Write("Введите знаменатель (> 0): ");
            int denominator = int.Parse(Console.ReadLine());

            // Проверка корректности ввода
            if (numerator < 0 || denominator <= 0)
            {
                Console.WriteLine("Ошибка: числитель ≥ 0, знаменатель > 0.");
                return;
            }

            // Особый случай: числитель равен 0
            if (numerator == 0)
            {
                Console.WriteLine("Результат: 0");
                return;
            }

            // Вычисляем НОД
            int gcd = Gcd(numerator, denominator);

            // Сокращаем
            int newNum = numerator / gcd;
            int newDen = denominator / gcd;

            Console.WriteLine($"\nИсходная дробь:     {numerator}/{denominator}");
            Console.WriteLine($"НОД({numerator}, {denominator}) = {gcd}");
            Console.WriteLine($"Сокращённая дробь:  {newNum}/{newDen}");

            // Если знаменатель стал 1 — выводим просто число
            if (newDen == 1)
                Console.WriteLine($"Это целое число: {newNum}");
        }

        // НОД через алгоритм Евклида
        static int Gcd(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}