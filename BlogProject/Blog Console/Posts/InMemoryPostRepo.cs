using Microsoft.VisualBasic.FileIO;

namespace BlogProject
{
    public class InMemoryPostRepo : IPostRepo
    {
        private Dictionary<int, Post> inMemoryDatabase = new Dictionary<int, Post>();

        private int keyID = 0;

        public InMemoryPostRepo()
        {
            LoadFromCSV();
        }

        private void LoadFromCSV() {
            TextFieldParser parser = new TextFieldParser(@"\Users\mgravermoen10105\Documents\Karmak Blog Project\BlogProject\blogPostStorage.csv")
            {
                TextFieldType = FieldType.Delimited,
                HasFieldsEnclosedInQuotes = true
            };
            parser.SetDelimiters(",");

            while (!parser.EndOfData)
            {
                string[] row = parser.ReadFields();
                Post post = new Post()
                {
                    Title = row[0],
                    Body = row[1],
                    Author = row[2],
                    Created = DateTime.Parse(row[3])
                };
                AddPost(post);
                Console.WriteLine();
            }
        }

        private void SaveToCSV() {
            String csvData = String.Join("\n", inMemoryDatabase.Select(d => $"\"{d.Value.Title}\",\"{d.Value.Body}\",\"{d.Value.Author}\",\"{d.Value.Created}\""));
            System.IO.File.WriteAllText(@"\Users\mgravermoen10105\Documents\Karmak Blog Project\BlogProject\blogPostStorage.csv", csvData);
        }

        public void AddPost(Post post)
        {
            keyID++;
            post.KeyID = keyID;
            inMemoryDatabase.Add(keyID, post);
            SaveToCSV();
        }

        public Post GetPost(int id)
        {
            return inMemoryDatabase[id];
        }

        public List<Post> CreateList()
        {
            List<Post> posts = [.. inMemoryDatabase.Values];

            posts.Sort((x, y) => y.Created.CompareTo(x.Created));
            
            return posts;
        }

        public void DeleteKey(int id)
        {
            inMemoryDatabase.Remove(id);
            SaveToCSV();
        }

        public void UpdateKey(Post post)
        {
            inMemoryDatabase[post.KeyID] = post;
            SaveToCSV();
        }

        public List<Post> CreateSearchedList(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}