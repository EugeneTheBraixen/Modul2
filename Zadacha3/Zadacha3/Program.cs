using System;
using System.Collections.Generic;

class Author
{
    public string Name { get; set; }
    public int BirthYear { get; set; }

    public Author(string name, int birthYear)
    {
        Name = name;
        BirthYear = birthYear;
    }

    public override string ToString()
    {
        return $"Автор: {Name}, Год рождения: {BirthYear}";
    }
}

class Book
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public Author Author { get; set; }

    public Book(string title, int releaseYear, Author author)
    {
        Title = title;
        ReleaseYear = releaseYear;
        Author = author;
    }

    public override string ToString()
    {
        return $"Название книги: {Title}, Год выпуска: {ReleaseYear}\n{Author}";
    }
}

class Program
{
    static void Main()
    {
        List<Author> authors = new List<Author>();
        List<Book> books = new List<Book>();

        while (true)
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить автора");
            Console.WriteLine("2. Добавить книгу");
            Console.WriteLine("3. Вывести информацию");
            Console.WriteLine("=======================================");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Введите имя автора: ");
                    string authorName = Console.ReadLine();
                    Console.Write("Введите год рождения автора: ");
                    int authorBirthYear = int.Parse(Console.ReadLine());
                    Author author = new Author(authorName, authorBirthYear);
                    authors.Add(author);
                    break;

                case 2:
                    Console.Write("Введите название книги: ");
                    string bookTitle = Console.ReadLine();
                    Console.Write("Введите год выпуска книги: ");
                    int bookReleaseYear = int.Parse(Console.ReadLine());

                    Console.WriteLine("Выберите автора (введите номер):");
                    for (int i = 0; i < authors.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {authors[i].Name}");
                    }
                    int authorIndex = int.Parse(Console.ReadLine()) - 1;
                    if (authorIndex >= 0 && authorIndex < authors.Count)
                    {
                        Author selectedAuthor = authors[authorIndex];
                        Book book = new Book(bookTitle, bookReleaseYear, selectedAuthor);
                        books.Add(book);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Неверный номер автора.");
                    }
                    break;

                case 3:
                    Console.WriteLine("-=======================================-");
                    Console.WriteLine("Информация об авторах:");
                    foreach (var a in authors)
                    {
                        Console.WriteLine(a);
                    }

                    Console.WriteLine("\nИнформация о книгах:");
                    foreach (var b in books)
                    {
                        Console.WriteLine(b);
                    }
                    Console.WriteLine("-=======================================-");
                    break;

                default:
                    Console.WriteLine("Ошибка! Неверный выбор.");
                    break;
            }
        }
    }
}
