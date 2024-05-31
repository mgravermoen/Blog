namespace BlogProject
{
    public class QuitCommand : ICommand
    {

        private readonly IConsole _console;

        public QuitCommand(IConsole console)
        {
            _console = console;
        }

        public bool IsListNeeded()
        {
            return false;
        }

        public void DisplayLogic()
        {
            _console.WriteLine("Exiting application...", ConsoleColor.Green);
            System.Environment.Exit(1);
        }
    }
}