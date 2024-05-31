using Npgsql;
using Microsoft.Extensions.Configuration;

namespace BlogProject
{
    public class AccountRepo : IAccountRepo
    {

        private string _connectionString;

        public AccountRepo(IConfiguration config)
        {
            _connectionString = config["AppConnectionString"];
        }

        public bool CheckUsername(string username)
        {
            using NpgsqlConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = "SELECT EXISTS (SELECT 1 FROM accounts WHERE username = '" + username + "')";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            return bool.Parse(reader[0].ToString());
        }

        public string GetPassword(string username)
        {
            using NpgsqlConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = "SELECT hash FROM accounts WHERE username = '" + username + "'";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            return reader[0].ToString();
        }

        public string GetRole(string username)
        {
            using NpgsqlConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = "SELECT role FROM accounts WHERE username = '" + username + "'";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            return reader[0].ToString();
        }

        public string GetSalt(string username)
        {
            using NpgsqlConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = "SELECT salt FROM accounts WHERE username = '" + username + "'";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            return reader[0].ToString();
        }

        public void StoreAccount(string username, string hash, string salt)
        {
            using NpgsqlConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = "INSERT INTO accounts (username, hash, salt, role) VALUES ('" + username + "', '" + hash + "', '" + salt + "', 'user')";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            cmd.ExecuteReader();
        }
    }
}