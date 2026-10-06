using System;

// 1. Делегаты для разных типов уведомлений
// Каждый делегат описывает сигнатуру обработчика
public delegate void MessageHandler(string sender, string text);
public delegate void CallHandler(string caller, TimeSpan duration);
public delegate void EmailHandler(string sender, string subject, string body);

// 2. Класс-издатель "Уведомление"
public class Notification
{
    // События
    // event — это обёртка над делегатом, доступная только
    // для += и -= извне класса
    public event MessageHandler OnMessage;
    public event CallHandler OnCall;
    public event EmailHandler OnEmail;

    // Методы, инициирующие события
    public void SendMessage(string sender, string text)
    {
        Console.WriteLine($"\n[СИСТЕМА] Новое сообщение от {sender}");
        OnMessage?.Invoke(sender, text);   // ?. — защита от null
    }

    public void MakeCall(string caller, TimeSpan duration)
    {
        Console.WriteLine($"\n[СИСТЕМА] Звонок от {caller}");
        OnCall?.Invoke(caller, duration);
    }

    public void SendEmail(string sender, string subject, string body)
    {
        Console.WriteLine($"\n[СИСТЕМА] Новое письмо от {sender}");
        OnEmail?.Invoke(sender, subject, body);
    }
}

class Program
{
    static void Main()
    {
        var notifier = new Notification();

        // Регистрация обработчиков
        // Можно подписывать разные методы на одно событие

        // Обработчики для сообщений
        notifier.OnMessage += ShowMessagePopup;
        notifier.OnMessage += PlaySound;

        // Обработчики для звонков
        notifier.OnCall += ShowCallScreen;
        notifier.OnCall += Vibrate;

        // Обработчики для писем
        notifier.OnEmail += ShowEmailNotification;

        // Генерация событий
        notifier.SendMessage("Анна", "Привет! Как дела?");
        notifier.MakeCall("Иван", TimeSpan.FromMinutes(2.5));
        notifier.SendEmail("support@mail.com", "Подтверждение заказа", "Ваш заказ отправлен");

        // Отписка от события
        Console.WriteLine("\n--- Отписываемся от звука ---");
        notifier.OnMessage -= PlaySound;

        notifier.SendMessage("Пётр", "Напоминание о встрече");
    }

    // Обработчики сообщений
    static void ShowMessagePopup(string sender, string text)
    {
        Console.WriteLine($"  [Всплывающее окно] {sender}: {text}");
    }

    static void PlaySound(string sender, string text)
    {
        Console.WriteLine($"  [Звук] Дзынь! Новое сообщение от {sender}");
    }

    // Обработчики звонков
    static void ShowCallScreen(string caller, TimeSpan duration)
    {
        Console.WriteLine($"  [Экран звонка] {caller} звонит... (длительность: {duration.TotalMinutes:F1} мин)");
    }

    static void Vibrate(string caller, TimeSpan duration)
    {
        Console.WriteLine($"  [Вибрация] Вжжж-вжжж");
    }

    // Обработчики писем
    static void ShowEmailNotification(string sender, string subject, string body)
    {
        Console.WriteLine($"  [Email] От: {sender}");
        Console.WriteLine($"      Тема: {subject}");
        Console.WriteLine($"      Текст: {body}");
    }
}