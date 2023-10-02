using System;

// Абстрактный класс "Геометрическая фигура"
abstract class Shape
{
    // Абстрактный метод для вычисления площади
    public abstract double CalculateArea();
}

// Класс "Круг"
class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        if (radius >= 0)
        {
            this.radius = radius;
        }
        else
        {
            Console.WriteLine("Ошибка! Радиус не может быть отрицательным. Устанавливаю радиус равным нулю.");
            this.radius = 0;
        }
    }

    // Реализация метода для вычисления площади круга
    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }
}

// Класс "Прямоугольник"
class Rectangle : Shape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        if (width >= 0 && height >= 0)
        {
            this.width = width;
            this.height = height;
        }
        else
        {
            Console.WriteLine("Ошибка! Ширина и высота не могут быть отрицательными. Устанавливаю их равными нулю.");
            this.width = 0;
            this.height = 0;
        }
    }

    // Реализация метода для вычисления площади прямоугольника
    public override double CalculateArea()
    {
        return width * height;
    }
}

// Класс "Треугольник"
class Triangle : Shape
{
    private double sideA;
    private double sideB;
    private double sideC;

    public Triangle(double sideA, double sideB, double sideC)
    {
        if (sideA >= 0 && sideB >= 0 && sideC >= 0)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }
        else
        {
            Console.WriteLine("Ошибка! Длины сторон не могут быть отрицательными. Устанавливаю их равными нулю.");
            this.sideA = 0;
            this.sideB = 0;
            this.sideC = 0;
        }
    }

    // Реализация метода для вычисления площади треугольника по формуле Герона
    public override double CalculateArea()
    {
        double s = (sideA + sideB + sideC) / 2;
        return Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите данные для круга:");
        double circleRadius;
        do
        {
            Console.Write("Введите радиус круга (неотрицательное число): ");
        } while (!double.TryParse(Console.ReadLine(), out circleRadius) || circleRadius < 0);
        Shape circle = new Circle(circleRadius);

        Console.WriteLine("Введите данные для прямоугольника:");
        double rectangleWidth, rectangleHeight;
        do
        {
            Console.Write("Введите ширину прямоугольника (неотрицательное число): ");
        } while (!double.TryParse(Console.ReadLine(), out rectangleWidth) || rectangleWidth < 0);
        do
        {
            Console.Write("Введите высоту прямоугольника (неотрицательное число): ");
        } while (!double.TryParse(Console.ReadLine(), out rectangleHeight) || rectangleHeight < 0);
        Shape rectangle = new Rectangle(rectangleWidth, rectangleHeight);

        Console.WriteLine("Введите данные для треугольника:");
        double triangleSideA, triangleSideB, triangleSideC;
        do
        {
            Console.Write("Введите длину стороны A треугольника (неотрицательное число): ");
        } while (!double.TryParse(Console.ReadLine(), out triangleSideA) || triangleSideA < 0);
        do
        {
            Console.Write("Введите длину стороны B треугольника (неотрицательное число): ");
        } while (!double.TryParse(Console.ReadLine(), out triangleSideB) || triangleSideB < 0);
        do
        {
            Console.Write("Введите длину стороны C треугольника (неотрицательное число): ");
        } while (!double.TryParse(Console.ReadLine(), out triangleSideC) || triangleSideC < 0);
        Shape triangle = new Triangle(triangleSideA, triangleSideB, triangleSideC);

        // Вычисляем и выводим площади фигур
        Console.WriteLine($"Площадь круга: {circle.CalculateArea()}");
        Console.WriteLine($"Площадь прямоугольника: {rectangle.CalculateArea()}");
        Console.WriteLine($"Площадь треугольника: {triangle.CalculateArea()}");

        Console.ReadLine();
    }
}