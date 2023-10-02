using System;

class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }

    public Car(string brand, string model, int year, double price)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Price = price;
    }

    public double CalculatePriceWithDiscount(double discountPercentage)
    {
        if (discountPercentage < 0 || discountPercentage > 100)
        {
            throw new ArgumentException("Скидка должна быть в пределах от 0 до 100.");
        }

        double discountedPrice = Price * (1 - (discountPercentage / 100));
        return discountedPrice;
    }

    public double CalculatePriceWithVAT(double vatPercentage)
    {
        if (vatPercentage < 0)
        {
            throw new ArgumentException("Налог на добавленную стоимость не может быть отрицательным.");
        }

        double priceWithVAT = Price * (1 + (vatPercentage / 100));
        return priceWithVAT;
    }

    public override string ToString()
    {
        return $"Марка: {Brand}, Модель: {Model}, Год выпуска: {Year}, Цена: {Price:C}";
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите данные об автомобиле:");

        Console.Write("Марка: ");
        string brand = Console.ReadLine();

        Console.Write("Модель: ");
        string model = Console.ReadLine();

        Console.Write("Год выпуска: ");
        if (int.TryParse(Console.ReadLine(), out int year))
        {
            Console.Write("Цена: ");
            if (double.TryParse(Console.ReadLine(), out double price))
            {
                Car car = new Car(brand, model, year, price);

                Console.WriteLine("\nИнформация о автомобиле:");
                Console.WriteLine(car);

                Console.Write("\nВведите процент скидки: ");
                if (double.TryParse(Console.ReadLine(), out double discountPercentage))
                {
                    double discountedPrice = car.CalculatePriceWithDiscount(discountPercentage);
                    Console.WriteLine($"Стоимость с учетом скидки: {discountedPrice:C}");
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите корректный процент скидки.");
                }

                Console.Write("\nВведите процент налога на добавленную стоимость (VAT): ");
                if (double.TryParse(Console.ReadLine(), out double vatPercentage))
                {
                    double priceWithVAT = car.CalculatePriceWithVAT(vatPercentage);
                    Console.WriteLine($"Стоимость с учетом налога на добавленную стоимость: {priceWithVAT:C}");
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите корректный процент налога на добавленную стоимость.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка! Введите корректную цену.");
            }
        }
        else
        {
            Console.WriteLine("Ошибка! Введите корректный год выпуска.");
        }

        Console.ReadLine();
    }
}
