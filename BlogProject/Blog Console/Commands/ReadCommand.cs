namespace BlogProject
{
    public class ReadCommand : ICommand
    {
        private readonly IPostService _service;

        private readonly IConsole _console;

        public ReadCommand(IPostService service, IConsole console)
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

            _console.Write("Please select the number of the post you'd like to read: ");
            while (true)
            {
                try
                {
                    int selection = Int32.Parse(_console.ReadLine()) - 1;
                    if (selection == -1) { return; }
                    int id = posts[selection].KeyID;
                    Post post = _service.ReadPost(id);
                    _console.Write("\n" + post.Title + "\n\n" + post.Author);
                    _console.CursorLeft(_console.BufferWidth() / 4 - 20);
                    _console.WriteLine(post.Created + "\n\n\n" + post.Body);
                    break;
                }
                catch (FormatException)
                {
                    _console.Write("ERROR -- Please enter a valid number: ", ConsoleColor.Red);
                }
                catch (ArgumentOutOfRangeException)
                {
                    _console.Write("ERROR -- Please select one of the listed numbers: ", ConsoleColor.Red);
                }
            }
        }
    }
}