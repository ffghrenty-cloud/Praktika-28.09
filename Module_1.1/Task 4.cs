using System;

namespace CitySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Массив из 5 городов
            string[] cities = { "Минск", "Москва", "Киев", "Варшава", "Берлин" };

            // Показываем список городов
            Console.WriteLine("Список городов:");
            for (int i = 0; i < cities.Length; i++)
                Console.WriteLine($"  {i}: {cities[i]}");

            Console.Write("\nВведите название города: ");
            string search = Console.ReadLine();

            // Ищем город в массиве
            int index = -1;
            for (int i = 0; i < cities.Length; i++)
            {
                if (cities[i].Equals(search, StringComparison.OrdinalIgnoreCase))
                {
                    index = i;
                    break;
                }
            }

            // Выводим результат
            if (index != -1)
                Console.WriteLine($"Город \"{search}\" найден. Индекс: {index}");
            else
                Console.WriteLine($"Город \"{search}\" не найден в массиве.");
        }
    }
}