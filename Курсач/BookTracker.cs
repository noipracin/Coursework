using System;
using System.Collections.Generic;
using System.Linq;

class BookTracker
{
    private List<Book> books = new List<Book>();

    public void Run()
    {
        string input;
        do
        {
            Console.WriteLine("Выберите действие: поиск/добавление/удаление/закончить программу");
            Console.WriteLine("1.Сортирока");
            Console.WriteLine("2.Поиск");
            Console.WriteLine("3.Добавление");
            Console.WriteLine("4.Удаление");
            Console.WriteLine("5.Закончить программу");
            input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "1":
                    SortBooks();
                    break;
                case "2":
                    SearchBooks();
                    break;
                case "3":
                    AddBook();
                    break;
                case "4":
                    RemoveBook();
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("Неверная команда. Попробуйте снова.");
                    break;
            }

        } while (input.ToLower() != "5");
    }

    private void SortBooks()
    {
        Console.WriteLine("По какому типу сортировать: (автор/название/состояние)");
        Console.WriteLine("1.Автор");
        Console.WriteLine("2.Название");
        Console.WriteLine("3.Состояние");
        string field = Console.ReadLine().ToLower();

        switch (field)
        {
            case "1":
                books = books.OrderBy(b => b.Author).ToList();
                break;
            case "2":
                books = books.OrderBy(b => b.Title).ToList();
                break;
            case "3":
                books = books.OrderBy(b => b.Status).ToList();
                break;
            default:
                Console.WriteLine("Неверная команда.");
                break;
        }

        PrintBooks();
    }

    private void SearchBooks()
    {
        Console.WriteLine("По какому типу искать?");
        Console.WriteLine("1.Автор");
        Console.WriteLine("2.Название");
        Console.WriteLine("3.Состояние");
        string field = Console.ReadLine().ToLower();

        Console.WriteLine("Введите значение для поиска:");
        string value = Console.ReadLine();

        List<Book> results = new List<Book>();

        switch (field)
        {
            case "1":
                results = books.Where(b => b.Author.ToLower().Contains(value.ToLower())).ToList();
                break;
            case "2":
                results = books.Where(b => b.Title.ToLower().Contains(value.ToLower())).ToList();
                break;
            case "3":
                results = books.Where(b => b.Status.ToLower().Contains(value.ToLower())).ToList();
                break;
            default:
                Console.WriteLine("Неверное тип для поиска.");
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


