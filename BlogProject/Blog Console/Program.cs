namespace BlogProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPostRepo repo = new InMemoryPostRepo();
            IPostService postService = new PostService(repo);
            ConsoleWrapper console = new ConsoleWrapper();
            string[] options = ["Write Post", "Read Post", "List All Posts", "Delete a Post", "Edit a Post", "Quit"];
            while (true)
            {
                DisplayMenuOptions(options, console);
                int selection = GetUserInput(options, console);
                DisplayMenuTitle(selection, console);
                ICommand command = GetSelection(selection, postService, console);

                if (command.IsListNeeded())
                {
                    if (postService.ListTitles().Count != 0)
                    {
                        ListCommand listObject = new(postService, console);
                        listObject.DisplayLogic();
                        if (selection != 3)
                        {
                            command.DisplayLogic();
                        }
                    }
                    else
                    {
                        console.WriteLine("ERROR -- No current entires.", ConsoleColor.Red);
                    }
                }
                else
                {
                    command.DisplayLogic();
                }

                console.SetCursorPosition(0, Console.BufferHeight - 1);
                console.Write("Request for main menu - press enter to confirm:");
                console.ReadLine();
            }
        }

        private static void DisplayMenuOptions(string[] options, ConsoleWrapper console)
        {
            console.Clear();
            console.WriteLine("~~~~~~~~~~~~~~~~~~~~~\n  -| KARMAK BLOG |-  \n~~~~~~~~~~~~~~~~~~~~~\n");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == options.Length - 1)
                {
                    console.SetCursorPosition(0, Console.BufferHeight - 2);
                    console.WriteLine("0--  " + options[i]);
                }
                else
                {
                    console.WriteLine(i + 1 + "--  " + options[i]);
                }
            }
        }

        private static int GetUserInput(string[] options, ConsoleWrapper console)
        {
            console.SetCursorPosition(0, Console.BufferHeight - 1);
            console.Write("Please enter your selection: ");
            while (true)
            {
                try
                {
                    int selection = Int32.Parse(console.ReadLine());
                    if (selection < 0 || selection >= options.Length)
                    {
                        console.Write("ERROR -- Invalid input. Please enter a number corresponding to the option you'd like to select: ", ConsoleColor.Red);
                    }
                    else
                    {
                        return selection;
                    }
                }
                catch (FormatException)
                {
                    console.Write("ERROR -- Please enter a valid number: ", ConsoleColor.Red);
                }
            }
        }

        private static void DisplayMenuTitle(int selection, ConsoleWrapper console)
        {
            console.Clear();

            string[] menuTitles = [" -| SHUTTING DOWN |- ", " -| NEW BLOG POST |- ", "  -| READ A POST |-  ", " -| LIST OF POSTS |- ", " -| DELETE A POST |- ", "  -| EDIT A POST |-  "];

            console.WriteLine("~~~~~~~~~~~~~~~~~~~~~\n" + menuTitles[selection] + "\n~~~~~~~~~~~~~~~~~~~~~\n");

            if (selection != 0) {
                console.WriteLine("You may enter \"0\" at any time to return to the main menu.\n");
            }
        }

        private static ICommand GetSelection(int selection, IPostService postService, ConsoleWrapper console)
        {
            switch (selection)
            {
                case 1:
                    WriteCommand writeObject = new(postService, console);
                    return writeObject;
                case 2:
                    ReadCommand readObject = new(postService, console);
                    return readObject;
                case 3:
                    ListCommand listObject = new(postService, console);
                    return listObject;
                case 4:
                    DeleteCommand deleteObject = new(postService, console);
                    return deleteObject;
                case 5:
                    EditCommand editObject = new(postService, console);
                    return editObject;
                default:
                    QuitCommand quitCommand = new(console);
                    return quitCommand;
            }
        }
    }
}