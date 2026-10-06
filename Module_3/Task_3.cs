using System;
using System.Collections.Generic;

// 1. Делегат-исполнитель. Описывает, как должна выполняться задача
public delegate void TaskExecutor(string taskName);

// 2. Класс "Задача"
public class TaskItem
{
    public string Name { get; set; }
    public TaskExecutor Executor { get; set; }
    public bool IsCompleted { get; private set; }

    public TaskItem(string name, TaskExecutor executor)
    {
        Name = name;
        Executor = executor;
    }

    // Выполнить задачу через делегат
    public void Execute()
    {
        if (IsCompleted)
        {
            Console.WriteLine($"Задача \"{Name}\" уже выполнена.");
            return;
        }

        Console.WriteLine($"\nВыполняется задача: \"{Name}\"");
        Executor?.Invoke(Name);   // делегат делает свою работу
        IsCompleted = true;
    }
}

// 3. Менеджер задач
public class TaskManager
{
    private readonly List<TaskItem> tasks = new List<TaskItem>();

    public void AddTask(string name, TaskExecutor executor)
    {
        tasks.Add(new TaskItem(name, executor));
        Console.WriteLine($"Добавлена задача: \"{name}\"");
    }

    public void ExecuteAll()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Список задач пуст.");
            return;
        }

        Console.WriteLine("\n=== Выполнение всех задач ===");
        foreach (var task in tasks)
        {
            task.Execute();
        }
    }

    public void ShowTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Список задач пуст.");
            return;
        }

        Console.WriteLine("\n=== Список задач ===");
        int i = 1;
        foreach (var task in tasks)
        {
            string status = task.IsCompleted ? "выполнена" : "ожидает";
            Console.WriteLine($"{i++}. {task.Name} [{status}]");
        }
    }
}

class Program
{
    // Способы выполнения задач (готовые методы под делегат)

    static void SendNotification(string taskName)
    {
        Console.WriteLine($"  -> Отправлено уведомление: \"{taskName}\"");
    }

    static void WriteToLog(string taskName)
    {
        Console.WriteLine($"  -> Запись в журнал: [{DateTime.Now:HH:mm:ss}] задача \"{taskName}\"");
    }

    static void SendEmail(string taskName)
    {
        Console.WriteLine($"  -> Email отправлен: \"{taskName}\"");
    }

    static void PrintToConsole(string taskName)
    {
        Console.WriteLine($"  -> Вывод в консоль: \"{taskName}\"");
    }

    static void Main()
    {
        var manager = new TaskManager();

        Console.WriteLine("=== Добавление задач ===");

        // Для каждой задачи выбираем своего делегата
        manager.AddTask("Купить продукты", SendNotification);
        manager.AddTask("Сделать отчёт", WriteToLog);
        manager.AddTask("Позвонить клиенту", SendEmail);

        // Можно использовать лямбда-выражение прямо на месте
        manager.AddTask("Помыть посуду", name =>
            Console.WriteLine($"  -> Домашнее дело: \"{name}\" выполнено!"));

        manager.ShowTasks();

        // Выполнение всех задач
        manager.ExecuteAll();

        manager.ShowTasks();

        // Повторный запуск уже выполненной задачи
        manager.ExecuteAll();
    }
}