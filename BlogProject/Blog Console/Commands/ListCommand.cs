namespace BlogProject
{
    public class ListCommand : ICommand
    {

        private readonly IPostService _service;

        private readonly IConsole _console;

        public ListCommand(IPostService service, IConsole console)
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
            
            int i = 1;
            foreach (Post post in posts)
            {
                _console.WriteLine(i + " -- " + post.Title + "\n");
                i++;
            }

        }
    }
}