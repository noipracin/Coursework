using System;
using System.Collections.Generic;
using System.Linq;

class Book
{
    public string Author { get; set; }
    public string Title { get; set; }
    public string Status { get; set; }
}

class BookTracker
{
    private List<Book> books = new List<Book>();

    public void Run()
    {
        string input;
        do
        {
            Console.WriteLine("Выберите действие: сортировка/поиск/добавление/удаление/закончить программу");
            input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "сортировка":
                    SortBooks();
                    break;
                case "поиск":
                    SearchBooks();
                    break;
                case "добавление":
                    AddBook();
                    break;
                case "удаление":
                    RemoveBook();
                    break;
                case "закончить программу":
                    break;
                default:
                    Console.WriteLine("Неверная команда. Попробуйте снова.");
                    break;
            }

        } while (input.ToLower() != "закончить программу");
    }

    private void SortBooks()
    {
        Console.WriteLine("По какому полю сортировать? (автор/название/состояние)");
        string field = Console.ReadLine().ToLower();

        switch (field)
        {
            case "автор":
                books = books.OrderBy(b => b.Author).ToList();
                break;
            case "название":
                books = books.OrderBy(b => b.Title).ToList();
                break;
            case "состояние":
                books = books.OrderBy(b => b.Status).ToList();
                break;
            default:
                Console.WriteLine("Неверное поле для сортировки.");
                break;
        }

        PrintBooks();
    }

    private void SearchBooks()
    {
        Console.WriteLine("По какому полю искать? (автор/название/состояние)");
        string field = Console.ReadLine().ToLower();

        Console.WriteLine("Введите значение для поиска:");
        string value = Console.ReadLine();

        List<Book> results = new List<Book>();

        switch (field)
        {
            case "автор":
                results = books.Where(b => b.Author.ToLower().Contains(value.ToLower())).ToList();
                break;
            case "название":
                results = books.Where(b => b.Title.ToLower().Contains(value.ToLower())).ToList();
                break;
            case "состояние":
                results = books.Where(b => b.Status.ToLower().Contains(value.ToLower())).ToList();
                break;
            default:
                Console.WriteLine("Неверное поле для поиска.");
                break;
        }

        if (results.Count == 0)
        {
            Console.WriteLine("Книги не найдены.");
        }
        else
        {
            foreach (var book in results)
            {
                Console.WriteLine($"Автор: {book.Author}, Название: {book.Title}, Состояние: {book.Status}");
            }
        }
    }

    private void AddBook()
    {
        Console.WriteLine("Введите информацию о книге:");
        Console.Write("Автор: ");
        string author = Console.ReadLine();
        Console.Write("Название: ");
        string title = Console.ReadLine();
        Console.Write("Состояние: ");
        string status = Console.ReadLine();

        books.Add(new Book { Author = author, Title = title, Status = status });

        PrintBooks();
    }

    private void RemoveBook()
    {
        PrintBooks();

        if (books.Count == 0)
        {
            Console.WriteLine("Список книг пуст.");
            return;
        }

        Console.WriteLine("Введите номер книги для удаления:");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= books.Count)
        {
            books.RemoveAt(index - 1);
            PrintBooks();
        }
        else
        {
            Console.WriteLine("Неверный номер книги.");
        }
    }

    private void PrintBooks()
    {
        for (int i = 0; i < books.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Автор: {books[i].Author}, Название: {books[i].Title}, Состояние: {books[i].Status}");
        }
    }
}

class Program
{
    static void Main()
    {
        BookTracker bookTracker = new BookTracker();
        bookTracker.Run();
    }
}
