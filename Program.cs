
class Library
{
    private List<string> _booksList = new List<string>();

    public void AddBook()
    {
        Console.WriteLine("=== Enter book name ===");
        string book = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(book))
        {
            Console.WriteLine("=== It`s not a book's name ===");
            Console.WriteLine("=== Do you wanna enter other book name? [yes / no] ===");
            string? action = Console.ReadLine()?.ToLower().Trim();

            if (action == "yes")
            {
                Console.WriteLine("=== Enter book name ===");
                string? retryBookName = Console.ReadLine();
                _booksList.Add(retryBookName!);
                return;
            }
            else if (action == "no") { DoSelect(); return; }

            Console.WriteLine("*** Unknown command ***");
            DoSelect();
        }
        _booksList.Add(book!);
        DoSelect();
    }

    public void DeleteBook()
    {
        Console.WriteLine("=== Enter index of book that you wanna delete ===");
        bool indexBool = int.TryParse(Console.ReadLine()!.Trim(), out int index);

        if (indexBool)
        {
            if (index < 0 || index >= _booksList.Count)
            {
                Console.WriteLine("*** There is no book with this index ***");
                DeleteBook();
                return;
            }
            Console.WriteLine($"=== The book '{_booksList[index]}' is removed ===");
            _booksList.RemoveAt(index!);
            DoSelect();
            return;
        }
        Console.WriteLine("*** Unknown command ***");
        DoSelect();
    }

    public void DoSelect()
    {
        Console.WriteLine("=== Select action: [add / delete / show / find / exit] ===");
        string? answ = Console.ReadLine()?.ToLower().Trim();

        switch (answ)
        {
            case "add":
                AddBook();
                break;
            case "delete":
                DeleteBook();
                break;
            case "show":
                ShowBooks();
                break;
            case "find":
                FindBook();
                break;
            case "exit":
                break;
            default:
                Console.WriteLine("*** Unknown command ***");
                DoSelect();
                break;
        }
    }

    public void ShowBooks() 
    {
        if (_booksList.Count <= 0)
        {
            Console.WriteLine("*** Library is empty. Add book? [yes / no] ***");
            string? action = Console.ReadLine()?.ToLower().Trim();

            if (action == "yes") { AddBook(); return; }
            else if (action == "no") { DoSelect(); return; }
           
            Console.WriteLine("*** Unknown command ***");
            DoSelect();
        }

        Console.WriteLine("*******************************");
        for (int i = 0; i < _booksList.Count; i++)
        {
            Console.WriteLine($"{i}: {_booksList[i]}");
        }
        Console.WriteLine("*******************************");
        DoSelect();
    }

    public void FindBook()
    {
        Console.WriteLine("=== Enter index of book ===");
        bool indexBool = int.TryParse(Console.ReadLine()!.Trim(), out int index);

        if (indexBool)
        {
            if (index < 0 || index >= _booksList.Count)
            {
                Console.WriteLine("*** There is no book with this index ***");
                FindBook();
                return;
            }
            Console.WriteLine($"=== Name: {_booksList[index]}, index: {index} ===");
            DoSelect();
            return;
        }
        Console.WriteLine("*** Unknown command ***");
        DoSelect();
    }

    public void StartProg()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=== Hi, it's your library ===");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("=== Show book or add ? [show / add / exit] ===");
        string? action = Console.ReadLine()?.ToLower().Trim();

        switch (action)
        {
            case "show":
                ShowBooks();
                break;
            case "add":
                AddBook();
                break;
            case "exit":
                break;
            default:
                Console.WriteLine("*** Unknown command ***");
                DoSelect();
                break;
        }
    }
}

class Program
{
    static void Main()
    {
        var library = new Library();
        library.StartProg();
    }
}
