using System;

class Shape
{
    public virtual double Area()
    {
        return 0;
    }

    public virtual double Perimeter()
    {
        return 0;
    }
}

class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double Area()
    {
        return Math.PI * radius * radius;
    }

    public override double Perimeter()
    {
        return 2 * Math.PI * radius;
    }
}

class Rectangle : Shape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public override double Area()
    {
        return width * height;
    }

    public override double Perimeter()
    {
        return 2 * (width + height);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Выберите фигуру:");
        Console.WriteLine("1. Круг");
        Console.WriteLine("2. Прямоугольник");

        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            Console.Write("Введите радиус круга: ");
            double radius = double.Parse(Console.ReadLine());
            Shape shape = new Circle(radius);

            Console.WriteLine("Круг:");
            Console.WriteLine("Площадь: " + shape.Area());
            Console.WriteLine("Периметр: " + shape.Perimeter());
        }
        else if (choice == 2)
        {
            Console.Write("Введите ширину прямоугольника: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Введите высоту прямоугольника: ");
            double height = double.Parse(Console.ReadLine());
            Shape shape = new Rectangle(width, height);

            Console.WriteLine("Прямоугольник:");
            Console.WriteLine("Площадь: " + shape.Area());
            Console.WriteLine("Периметр: " + shape.Perimeter());
        }
        else
        {
            Console.WriteLine("Ошибка! Неправильный выбор.");
        }

        Console.ReadLine();
    }
}
