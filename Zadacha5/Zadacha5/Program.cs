using System;

class TemperatureChangedEventArgs : EventArgs
{
    public double NewTemperature { get; }

    public TemperatureChangedEventArgs(double newTemperature)
    {
        NewTemperature = newTemperature;
    }
}

class TemperatureSensor
{
    private double currentTemperature;

    public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;

    public double CurrentTemperature
    {
        get { return currentTemperature; }
        set
        {
            if (currentTemperature != value)
            {
                currentTemperature = value;
                OnTemperatureChanged(new TemperatureChangedEventArgs(value));
            }
        }
    }

    protected virtual void OnTemperatureChanged(TemperatureChangedEventArgs e)
    {
        TemperatureChanged?.Invoke(this, e);
    }
}

class Thermostat
{
    public void StartMonitoring(TemperatureSensor sensor)
    {
        sensor.TemperatureChanged += Sensor_TemperatureChanged;
    }

    public void StopMonitoring(TemperatureSensor sensor)
    {
        sensor.TemperatureChanged -= Sensor_TemperatureChanged;
    }

    private void Sensor_TemperatureChanged(object sender, TemperatureChangedEventArgs e)
    {
        if (e.NewTemperature < 20)
        {
            Console.WriteLine("Температура слишком низкая. Включаем отопление.");
        }
        else if (e.NewTemperature > 25)
        {
            Console.WriteLine("Температура слишком высокая. Выключаем отопление.");
        }
        else
        {
            Console.WriteLine("Температура в норме.");
        }
    }
}

class Program
{
    static void Main()
    {
        TemperatureSensor sensor = new TemperatureSensor();
        Thermostat thermostat = new Thermostat();

        Console.WriteLine("Введите текущую температуру:");
        if (double.TryParse(Console.ReadLine(), out double initialTemperature))
        {
            sensor.CurrentTemperature = initialTemperature;

            thermostat.StartMonitoring(sensor);

            while (true)
            {
                Console.WriteLine("Введите новую температуру (или 'exit' для выхода):");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break;
                }

                if (double.TryParse(input, out double newTemperature))
                {
                    sensor.CurrentTemperature = newTemperature;
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите корректное число.");
                }
            }

            thermostat.StopMonitoring(sensor);
        }
        else
        {
            Console.WriteLine("Ошибка! Введите корректное число.");
        }

        Console.ReadLine();
    }
}
