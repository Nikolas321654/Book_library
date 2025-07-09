
class Library
{
    private List<string> _booksList = new List<string>();

    public void AddBook()
    {
        Console.WriteLine("=== Enter book name ===");
        string? book = Console.ReadLine();

        if (book == "")
        {
            Console.WriteLine("=== It`s not a book's name ===");
            Console.WriteLine("=== Do you wanna enter other book name? [yes / no] ===");
            string? action = Console.ReadLine()?.ToLower().Trim();

            if (action == "yes")
            {
                Console.WriteLine("=== Enter book name ===");
                string? retryBookName = Console.ReadLine();
                _booksList.Add(retryBookName!);
            }
            else if (action == "no")
            {
                Selector();
                return;
            }
        }
        _booksList.Add(book!);
        Selector();
    }

    public void Delete()
    {
        Console.WriteLine("=== Enter index of book that you wanna delete ===");
        int index = int.Parse(Console.ReadLine().Trim());
        Console.WriteLine($"=== The book '{_booksList[index]}' is removed ===");
        _booksList.RemoveAt(index!);
        Selector();
    }

    public void Selector()
    {
        Console.WriteLine("=== Select action: [add / delete / show / find / exit] ===");
        string? answ = Console.ReadLine()?.ToLower().Trim();

        switch (answ!.ToLower().Trim())
        {
            case "add":
                AddBook();
                break;
            case "delete":
                Delete();
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
                Selector();
                break;
        }
    }

    public void ShowBooks()
    {
        if (_booksList.Count <= 0)
        {
            Console.WriteLine("*** Library is empty. Add book? [yes / no] ***");
            string? action = Console.ReadLine()?.ToLower().Trim();

            if (action == "yes")
            {
                AddBook();
                return;
            }
            else if (action == "no")
            {
                Selector();
            }
        }

        Console.WriteLine("*******************************");
        for (int i = 0; i < _booksList.Count; i++)
        {
            Console.WriteLine($"{i}: {_booksList[i]}");
        }
        Console.WriteLine("*******************************");
        Selector();
    }

    public void FindBook()
    {
        Console.WriteLine("=== Enter id of book ===");
        string? answ = Console.ReadLine().Trim();
        Console.WriteLine("=== Name: {0}, id: {1} ===", _booksList[int.Parse(answ)], answ);
        Selector();
    }

    public void StartProg()
    {
        Console.WriteLine("=== Hi, it's your library ===");
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
                Selector();
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
