namespace BlogProject
{
    public class EditCommand : ICommand
    {

        private readonly IPostService _service;

        private readonly IConsole _console;

        public EditCommand(IPostService service, IConsole console)
        {
            _service = service;
            _console = console;
        }

        public bool IsListNeeded()
        {
            return true;
        }

        public void DisplayLogic()
        {
            List<Post> posts = _service.ListTitles();
            _console.Write("Please select the number of the post you'd like to edit: ");
            while (true)
            {
                try
                {
                    int selection = Int32.Parse(_console.ReadLine()) - 1;
                    if (selection == -1) { return; }
                    int id = posts[selection].KeyID;
                    string field = GetUserSelection();
                    if (field == "t")
                    {
                        bool mainMenu = EditTitle(id);
                        if (mainMenu) { break; }
                    }
                    else if (field == "b")
                    {
                        bool mainMenu = EditBody(id);
                        if (mainMenu) { break; }
                    }
                    else
                    {
                        bool mainMenu = EditAuthor(id);
                        if (mainMenu) { break; }
                    }
                    _console.WriteLine("\nThe post titled \"" + posts[selection].Title + "\" was edited.", ConsoleColor.Green);
                    break;
                }
                catch (FormatException)
                {
                    _console.Write("ERROR -- Please enter a valid number: ", ConsoleColor.Red);
                }
                catch (ArgumentNullException)
                {
                    _console.Write("ERROR -- Please enter a valid number: ", ConsoleColor.Red);
                }
                catch (ArgumentOutOfRangeException)
                {
                    _console.Write("ERROR -- Please select one of the listed numbers: ", ConsoleColor.Red);
                }
            }
        }


        private string GetUserSelection()
        {
            _console.Write("Which would you like to edit - the title or the body?\nSelect \"t\" for title, \"b\" for body, or \"a\" for author: ");
            while (true)
            {
                string selection = _console.ReadLine();
                if (selection != "t" && selection != "b" && selection != "a")
                {
                    _console.Write("ERROR -- Please enter a valid option: ", ConsoleColor.Red);
                }
                else
                {
                    return selection;
                }
            }
        }

        private bool EditTitle(int id)
        {
            _console.Write("Please enter your new title: ");
            while (true)
            {
                string newTitle = _console.ReadLine();
                if (newTitle == "" || String.IsNullOrWhiteSpace(newTitle))
                {
                    _console.Write("ERROR -- Please enter a valid title: ", ConsoleColor.Red);
                }
                else if (newTitle == "0")
                {
                    return true;
                }
                else
                {
                    Post post = _service.ReadPost(id);
                    Post newPost = new Post()
                    {
                        Title = newTitle,
                        Body = post.Body,
                        KeyID = post.KeyID,
                        Author = post.Author
                    };
                    _service.updatePost(newPost);
                    return false;
                }
            }
        }

        private bool EditBody(int id)
        {
            _console.Write("Please enter the body of your edited post. Newlines may be denoted with \"!!\": ");
            while (true)
            {
                string newBody = _console.ReadLine();
                if (newBody == "" || String.IsNullOrWhiteSpace(newBody))
                {
                    _console.Write("ERROR -- Please enter a valid body: ", ConsoleColor.Red);
                }
                else if (newBody == "0")
                {
                    return true;
                }
                else
                {
                    Post post = _service.ReadPost(id);
                    Post newPost = new Post()
                    {
                        Title = post.Title,
                        Body = newBody.Replace("!!", "\n"),
                        KeyID = post.KeyID,
                        Author = post.Author
                    };
                    _service.updatePost(newPost);
                    return false;
                }
            }
        }

        private bool EditAuthor(int id)
        {
            _console.Write("Please enter your new author: ");
            while (true)
            {
                string newAuthor = _console.ReadLine();
                if (newAuthor == "" || String.IsNullOrWhiteSpace(newAuthor))
                {
                    _console.Write("ERROR -- Please enter a valid author: ", ConsoleColor.Red);
                }
                else if (newAuthor == "0")
                {
                    return true;
                }
                else
                {
                    Post post = _service.ReadPost(id);
                    Post newPost = new Post()
                    {
                        Title = post.Title,
                        Body = post.Body,
                        KeyID = post.KeyID,
                        Author = newAuthor
                    };
                    _service.updatePost(newPost);
                    return false;
                }
            }
        }
    }
}