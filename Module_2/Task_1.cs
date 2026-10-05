using System;

class Person
 {
    public string name {get; set;} //имя 
    public int age{get; set;} //возраст
    public string address{get; set;} //адрес
    public void Print()
    {
        Console.WriteLine($"Имя: {name}, Возраст: {age}, Адрес: {address}");
    }
  }
class Program
{
    static void Main(string[]args)
    { Person user = new Person();//создание объекта класса

    Console.WriteLine("Введите свое имя:");
        user.name = Console.ReadLine();
        Console.WriteLine("Введите свое возраст:");
        user.age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите свой адрес:");
        user.address = Console.ReadLine(); 
    user.Print(); 
    //заданный объект:
    Person one = new Person();
    one.name    ="Петров";
    one.age     =24;
    one.address ="Ул. Пушкина, 9Б";
    one.Print();
    }
}    