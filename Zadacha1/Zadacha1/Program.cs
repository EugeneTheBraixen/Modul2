using System;
using System.Text.RegularExpressions;

class Person
{
    // Поля класса
    private string name;
    private int age;
    private string address;

    // Метод для проверки строки на наличие только русских букв, цифр и пробелов
    private bool IsRussianLettersAndNumbers(string str)
    {
        return Regex.IsMatch(str, "^[А-Яа-я0-9 . -]+$");
    }
    // Метод для установки имени
    public void SetName(string name)
    {
        if (IsRussianLetters(name))
        {
            this.name = name;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!Ошибка! Писать нужно только русскими буквами.!!");
            Console.ResetColor();
            return; // Завершаем работу метода и программы
        }
    }

    // Метод для получения имени
    public string GetName()
    {
        return name;
    }

    // Метод для установки возраста
    public void SetAge(int age)
    {
        if (age >= 0) // Проверяем, что возраст не отрицательный
        {
            this.age = age;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!Ошибка! Возраст не может быть отрицательным.!!");
            Console.ResetColor();
            return; // Завершаем работу метода и программы
        }
    }

    // Метод для получения возраста
    public int GetAge()
    {
        return age;
    }

    // Метод для установки адреса
    public void SetAddress(string address)
    {
        if (IsRussianLettersAndNumbers(address))
        {
            this.address = address;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!Ошибка! Адрес должен содержать только буквы, цифры и пробелы.!!");
            Console.ResetColor();
            return; // Завершаем работу метода и программы
        }
    }


    // Метод для получения адреса
    public string GetAddress()
    {
        return address;
    }

    // Метод для проверки строки на наличие только русских букв
    private bool IsRussianLetters(string str)
    {
        return Regex.IsMatch(str, "^[А-Яа-я ]+$");
    }
}

class Program
{
    static void Main()
    {
        // Создаем объекты класса Person
        Person person1 = new Person();
        Person person2 = new Person();

        // Вводим данные о первом человеке
        Console.WriteLine("--Введите данные о первом человеке:");
        Console.Write("--Имя: ");
        person1.SetName(Console.ReadLine());

        Console.Write("--Возраст: ");
        if (int.TryParse(Console.ReadLine(), out int age))
        {
            person1.SetAge(age);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!Ошибка! Возраст должен быть числом.!!");
            Console.ResetColor();
            return; // Завершаем программу
        }

        Console.Write("--Адрес: ");
        person1.SetAddress(Console.ReadLine());

        // Вводим данные о втором человеке
        Console.WriteLine("\n--Введите данные о втором человеке:");
        Console.Write("--Имя: ");
        person2.SetName(Console.ReadLine());

        Console.Write("--Возраст: ");
        if (int.TryParse(Console.ReadLine(), out age))
        {
            person2.SetAge(age);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!Ошибка! Возраст должен быть числом.!!");
            Console.ResetColor();
            return; // Завершаем программу
        }

        Console.Write("--Адрес: ");
        person2.SetAddress(Console.ReadLine());

        // Выводим информацию о person1
        Console.WriteLine("\n|Информация о первом человеке:");
        Console.WriteLine($"|Имя: {person1.GetName()}");
        Console.WriteLine($"|Возраст: {person1.GetAge()}");
        Console.WriteLine($"|Адрес: {person1.GetAddress()}");

        // Выводим информацию о person2
        Console.WriteLine("\n|Информация о втором человеке:");
        Console.WriteLine($"|Имя: {person2.GetName()}");
        Console.WriteLine($"|Возраст: {person2.GetAge()}");
        Console.WriteLine($"|Адрес: {person2.GetAddress()}");

        Console.ReadLine();
    }
}