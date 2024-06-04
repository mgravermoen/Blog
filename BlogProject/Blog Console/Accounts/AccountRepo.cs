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

        public dynamic ReturnVariableQuery(string query, string username)
        {
            using NpgsqlConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("USERNAME", username);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            var returnVar = reader[0].ToString();
            conn.Close();
            return returnVar;
        }

        public bool CheckUsername(string username)
        {
            return bool.Parse(ReturnVariableQuery("SELECT EXISTS (SELECT 1 FROM accounts WHERE username = :USERNAME)", username));
        }

        public string GetPassword(string username)
        {
            return ReturnVariableQuery("SELECT hash FROM accounts WHERE username = :USERNAME", username);
        }

        public string GetRole(string username)
        {
            return ReturnVariableQuery("SELECT role FROM accounts WHERE username = :USERNAME", username);
        }

        public string GetSalt(string username)
        {
            return ReturnVariableQuery("SELECT salt FROM accounts WHERE username = :USERNAME", username);
        }

        public void StoreAccount(string username, string hash, string salt)
        {
            using NpgsqlConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = "INSERT INTO accounts (username, hash, salt, role) VALUES (:USERNAME, :HASH, :SALT, 'user')";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("USERNAME", username);
            cmd.Parameters.AddWithValue("HASH", hash);
            cmd.Parameters.AddWithValue("SALT", salt);
            cmd.ExecuteReader();
            conn.Close();
        }
    }
}