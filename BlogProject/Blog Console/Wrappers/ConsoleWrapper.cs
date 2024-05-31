namespace BlogProject
{

    public class ConsoleWrapper : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string output, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(output);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void WriteLine(string output, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(output);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void CursorLeft(int position)
        {
            Console.CursorLeft = position;
        }

        public int BufferWidth()
        {
            return Console.BufferWidth;
        }
    }
}