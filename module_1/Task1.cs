using System;

namespace TemperatureConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n=== Конвертер температуры ===");
                Console.WriteLine("1. Цельсий → Фаренгейт");
                Console.WriteLine("2. Фаренгейт → Цельсий");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите пункт: ");

                string choice = Console.ReadLine();

                if (choice == "0")
                {
                    Console.WriteLine("До свидания!");
                    break;
                }

                if (choice != "1" && choice != "2")
                {
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    continue;
                }

                Console.Write("Введите температуру: ");
                if (!double.TryParse(Console.ReadLine(), out double temperature))
                {
                    Console.WriteLine("Ошибка: введите корректное число.");
                    continue;
                }

                if (choice == "1")
                {
                    double fahrenheit = CelsiusToFahrenheit(temperature);
                    Console.WriteLine($"{temperature}°C = {fahrenheit:F2}°F");
                }
                else
                {
                    double celsius = FahrenheitToCelsius(temperature);
                    Console.WriteLine($"{temperature}°F = {celsius:F2}°C");
                }
            }
        }

        // Формула: F = C * 9/5 + 32
        static double CelsiusToFahrenheit(double celsius)
        {
            return celsius * 9.0 / 5.0 + 32.0;
        }

        // Формула: C = (F - 32) * 5/9
        static double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32.0) * 5.0 / 9.0;
        }
    }
}
