namespace BlogProject;
public class WriteCommand : ICommand
{
    private readonly IPostService _service;

    private readonly IConsole _console;

    public WriteCommand(IPostService service, IConsole console)
    {
        _service = service;
        _console = console;
    }

    public bool IsListNeeded()
    {
        return false;
    }

    public void DisplayLogic()
    {
        (string title, bool mainMenu) = GetInput("title");
        if (mainMenu) { return; }
        (string body, mainMenu) = GetInput("body");
        if (mainMenu) { return; }
        (string author, mainMenu) = GetInput("author");
        if (mainMenu) { return; }

        Post post = new Post()
        {
            Title = title,
            Body = body.Replace("!!", "\n"),
            Created = DateTime.UtcNow,
            Author = author
        };
        _service.StorePost(post);

        _console.WriteLine("\nPost created successfully", ConsoleColor.Green);
    }

    private (string input, bool mainMenu) GetInput(string field)
    {
        _console.Write("Please enter the " + field + " of your post: ");
        while (true)
        {
            string input = _console.ReadLine();
            if (input == "" || String.IsNullOrWhiteSpace(input))
            {
                _console.Write("ERROR -- Please enter a valid " + field + ": ", ConsoleColor.Red);
            }
            else if (input == "0")
            {
                return (input, true);
            }
            else
            {
                return (input, false);
            }
        }
    }
}