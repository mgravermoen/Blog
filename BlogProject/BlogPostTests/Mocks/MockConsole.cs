using BlogProject;

namespace BlogPostTests {

    public class MockConsole : IConsole {

        public Queue<string> readQueue = new Queue<string>();

        public Queue<string> outputQueue = new Queue<string>();

        public void AssertQueuesAreEmpty() {
            Assert.Empty(readQueue);
            Assert.Empty(outputQueue);
        }

        public string ReadLine() {
            return readQueue.Dequeue();
        }

        public void AddToReadLineQueue(string input) {
            readQueue.Enqueue(input);
        }

        public string GetOutput() {
            return outputQueue.Dequeue();
        }

        public void WriteLine(string output, ConsoleColor color)
        {
            outputQueue.Enqueue(output);
        }

        public void Write(string output, ConsoleColor color)
        {
            outputQueue.Enqueue(output);
        }

        public void CursorLeft(int position)
        {
            // do nothing
        }

        public int BufferWidth()
        {
            return 0;
        }
    }

}