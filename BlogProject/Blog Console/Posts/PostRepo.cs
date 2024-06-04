using Npgsql;
using Microsoft.Extensions.Configuration;

namespace BlogProject
{
    public class PostRepo : IPostRepo
    {

        private string _connectionString;

        public PostRepo(IConfiguration config)
        {
            _connectionString = config["AppConnectionString"];
        }

        private void VoidQuery(string query, Post post) {
            using NpgsqlConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("TITLE", post.Title);
            cmd.Parameters.AddWithValue("BODY", post.Body);
            cmd.Parameters.AddWithValue("AUTHOR", post.Author);
            cmd.Parameters.AddWithValue("CREATED", post.Created);
            cmd.Parameters.AddWithValue("KEYID", post.KeyID);
            cmd.ExecuteReader();
            conn.Close();
        }

        private List<Post> ListQuery(string query, string searchTerm = "")
        {
            List<Post> posts = new List<Post>();

            using NpgsqlConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("SEARCHTERM", "%" + searchTerm + "%");
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read()) 
            {
                Post post = new Post()
                {
                    KeyID = Int32.Parse(reader[0].ToString()),
                    Title = reader[1].ToString(),
                    Body = reader[2].ToString(),
                    Author = reader[3].ToString(),
                    Created = DateTime.Parse(reader[4].ToString())
                };
                posts.Add(post);
            }
            conn.Close();
            posts.Sort((x, y) => y.Created.CompareTo(x.Created));
            return posts;
        }

        public void AddPost(Post post)
        {
            VoidQuery("INSERT INTO Posts (Title, Body, Author, Created) VALUES (:TITLE, :BODY, :AUTHOR, :CREATED)", post);
        }

        public List<Post> CreateList()
        {
            return ListQuery("SELECT * FROM Posts");
        }

        public List<Post> CreateSearchedList(string searchTerm)
        {
            return ListQuery("SELECT * FROM posts WHERE title ILIKE :SEARCHTERM", searchTerm);
        }

        public void DeleteKey(int id)
        {
            using NpgsqlConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            using NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM Posts WHERE KeyID = :ID", conn);
            cmd.Parameters.AddWithValue("ID", id);
            cmd.ExecuteReader();
            conn.Close();
        }

        public Post GetPost(int id)
        {
            using NpgsqlConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            using NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Posts WHERE KeyID = :ID", conn);
            cmd.Parameters.AddWithValue("ID", id);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Post post = new Post()
            {
                KeyID = Int32.Parse(reader[0].ToString()),
                Title = reader[1].ToString(),
                Body = reader[2].ToString(),
                Author = reader[3].ToString(),
                Created = DateTime.Parse(reader[4].ToString())
            };
            conn.Close();
            return post;
        }

        

        public void UpdateKey(Post post)
        {
            VoidQuery("UPDATE Posts SET Body = :BODY WHERE KeyID = :KEYID;" + 
                      " UPDATE Posts SET Created = :CREATED WHERE KeyID = :KEYID;", post);
        }
    }
}