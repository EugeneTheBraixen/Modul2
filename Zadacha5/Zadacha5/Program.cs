using System;
using System.Threading;

public class TemperatureChangedEventArgs : EventArgs
{
    public double NewTemperature { get; }

    public TemperatureChangedEventArgs(double newTemperature)
    {
        NewTemperature = newTemperature;
    }
}

public class TemperatureSensor
{
    private double currentTemperature;
    private readonly Timer temperatureTimer;

    public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;

    public TemperatureSensor()
    {
        currentTemperature = 20.0;
        temperatureTimer = new Timer(UpdateTemperature, null, 0, 5000); // Изменяйте температуру каждые 5 секунд
    }

    private void UpdateTemperature(object state)
    {
        Random random = new Random();
        double newTemperature = currentTemperature + (random.NextDouble() - 0.5) * 2.0; // Случайное изменение температуры

        if (newTemperature < -10.0)
        {
            newTemperature = -10.0;
        }
        else if (newTemperature > 40.0)
        {
            newTemperature = 40.0;
        }

        if (newTemperature != currentTemperature)
        {
            currentTemperature = newTemperature;
            OnTemperatureChanged(new TemperatureChangedEventArgs(newTemperature));
        }
    }

    protected virtual void OnTemperatureChanged(TemperatureChangedEventArgs e)
    {
        TemperatureChanged?.Invoke(this, e);
    }
}

public class Thermostat
{
    private double targetTemperature;

    public Thermostat(double targetTemperature)
    {
        this.targetTemperature = targetTemperature;
    }

    public void OnTemperatureChanged(object sender, TemperatureChangedEventArgs e)
    {
        Console.WriteLine($"Текущая температура: {e.NewTemperature:F2}°C");

        if (e.NewTemperature < targetTemperature)
        {
            Console.WriteLine("Включено отопление.");
        }
        else if (e.NewTemperature > targetTemperature)
        {
            Console.WriteLine("Отопление выключено.");
        }
        else
        {
            Console.WriteLine("Температура на уровне цели. Отопление остается выключенным.");
        }
    }
}

class Program
{
    static void Main()
    {
        Thermostat thermostat = new Thermostat(22.0);
        TemperatureSensor temperatureSensor = new TemperatureSensor();

        temperatureSensor.TemperatureChanged += thermostat.OnTemperatureChanged;

        Console.WriteLine("Симуляция изменения температуры. Для выхода нажмите Enter.");
        Console.ReadLine();
    }
}
