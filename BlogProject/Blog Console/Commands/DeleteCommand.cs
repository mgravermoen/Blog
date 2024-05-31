namespace BlogProject;
public class DeleteCommand : ICommand
{

    private readonly IPostService _service;

    private readonly IConsole _console;

    public DeleteCommand(IPostService service, IConsole console)
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

        _console.Write("Please select the number of the post you'd like to delete: ");
        while (true)
        {
            try
            {
                int selection = Int32.Parse(_console.ReadLine()) - 1;
                if (selection == -1) { return; }
                int id = posts[selection].KeyID;
                _service.DeletePost(id);
                _console.WriteLine("\nThe post titled \"" + posts[selection].Title + "\" was deleted.", ConsoleColor.Red);
                break;
            }
            catch (ArgumentOutOfRangeException)
            {
                _console.Write("ERROR -- Please select one of the listed numbers: ", ConsoleColor.Red);
            }
            catch (Exception)
            {
                _console.Write("ERROR -- Please enter a valid number: ", ConsoleColor.Red);
            }
        }
    }
}