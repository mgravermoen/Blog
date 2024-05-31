namespace BlogProject;

public interface IConsole
{

    public string ReadLine();

    public void WriteLine(string output, ConsoleColor color = ConsoleColor.White);

    public void Write(string output, ConsoleColor color = ConsoleColor.White);

    public void CursorLeft(int position);

    public int BufferWidth();
}
