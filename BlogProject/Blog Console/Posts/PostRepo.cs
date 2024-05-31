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

        private void SendQuery(string query) {
            using NpgsqlConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            cmd.ExecuteReader();
            conn.Close();
        }

        public void AddPost(Post post)
        {
            string query = "INSERT INTO Posts (Title, Body, Author, Created) VALUES ('" + post.Title + "', '" + post.Body + "', '" + post.Author + "', '" + post.Created + "')";
            SendQuery(query);
        }

        public List<Post> CreateList()
        {
            List<Post> posts = new List<Post>();

            using NpgsqlConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = "SELECT * FROM Posts";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
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

        public void DeleteKey(int id)
        {
            string query = "DELETE FROM Posts WHERE KeyID = " + id;
            SendQuery(query);
        }

        public Post GetPost(int id)
        {
            using NpgsqlConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = "SELECT * FROM Posts WHERE KeyID = " + id;
            using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
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
            string query = "UPDATE Posts SET Body = '" + post.Body + "' WHERE KeyID = " + post.KeyID  + ";" + 
                           " UPDATE Posts SET Created = '" + post.Created + "' WHERE KeyID = " + post.KeyID + ";";
            SendQuery(query);
        }
    }
}