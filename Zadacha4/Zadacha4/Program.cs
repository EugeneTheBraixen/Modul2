using System;

// Интерфейс для рисуемых объектов
interface IDrawable
{
    void Draw();
}

// Класс круга
class Circle : IDrawable
{
    public void Draw()
    {
        Console.WriteLine("Рисуем круг");
    }
}

// Класс прямоугольника
class Rectangle : IDrawable
{
    public void Draw()
    {
        Console.WriteLine("Рисуем прямоугольник");
    }
}

// Класс треугольника
class Triangle : IDrawable
{
    public void Draw()
    {
        Console.WriteLine("Рисуем треугольник");
    }
}

class Program
{
    static void Main()
    {
        // Создаем массив объектов, реализующих интерфейс IDrawable
        IDrawable[] drawables = new IDrawable[]
        {
            new Circle(),
            new Rectangle(),
            new Triangle()
        };

        // Вызываем метод Draw() для каждого объекта из массива
        foreach (var drawable in drawables)
        {
            drawable.Draw();
        }

        Console.ReadLine();
    }
}
