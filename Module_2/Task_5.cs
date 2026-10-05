using System;

public class TemperatureChangedEventArgs : EventArgs
{
    public double OldTemperature { get; }
    public double NewTemperature { get; }

    public TemperatureChangedEventArgs(double oldTemp, double newTemp)
    {
        OldTemperature = oldTemp;
        NewTemperature = newTemp;
    }
}

public class TemperatureSensor
{
    public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;

    private double _temperature;

    public double Temperature
    {
        get => _temperature;
        set
        {
            if (Math.Abs(_temperature - value) < 0.001)   // температура реально изменилась?
                return;

            double oldTemp = _temperature;
            _temperature = value;

            OnTemperatureChanged(new TemperatureChangedEventArgs(oldTemp, _temperature));
        }
    }

    protected virtual void OnTemperatureChanged(TemperatureChangedEventArgs e)
    {
        TemperatureChanged?.Invoke(this, e);   
    }
}

public class Thermostat
{
    private const double MinComfortTemp = 22.0;   // ниже — включаем отопление
    private const double MaxComfortTemp = 26.0;   // выше — выключаем

    public bool HeatingOn { get; private set; }

    //Метод-обработчик события
    public void OnTemperatureChanged(object sender, TemperatureChangedEventArgs e)
    {
        Console.WriteLine($"[Термостат] Температура: {e.OldTemperature:F1}°C → {e.NewTemperature:F1}°C");

        if (e.NewTemperature < MinComfortTemp && !HeatingOn)
        {
            HeatingOn = true;
            Console.WriteLine("Холодно! ВКЛЮЧАЮ отопление.");
        }
        else if (e.NewTemperature > MaxComfortTemp && HeatingOn)
        {
            HeatingOn = false;
            Console.WriteLine("Жарко! ВЫКЛЮЧАЮ отопление.");
        }
        else
        {
            Console.WriteLine($"Комфортно. Отопление {(HeatingOn ? "ВКЛ" : "ВЫКЛ")}.");
        }
    }
}

class Program
{
    static void Main()
    {
        TemperatureSensor sensor = new TemperatureSensor();
        Thermostat thermostat = new Thermostat();

        sensor.TemperatureChanged += thermostat.OnTemperatureChanged;

        //Изменяем температуру — термостат реагирует автоматически
        sensor.Temperature = 20.0;
        sensor.Temperature = 24.0;
        sensor.Temperature = 28.0;
        sensor.Temperature = 26.5;

        Console.WriteLine("\n--- Отписка термостата ---\n");
        sensor.TemperatureChanged -= thermostat.OnTemperatureChanged;

        sensor.Temperature = 15.0;   // термостат уже не реагирует
        Console.WriteLine("Термостат молчит, потому что отписался.");
    }
}