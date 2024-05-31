using System.Security.Cryptography;
using System.Text;

namespace BlogProject
{
    public class AccountService : IAccountService
    {

        private readonly IAccountRepo _repo;

        public AccountService(IAccountRepo repo)
        {
            _repo = repo;
        }

        public bool CheckUsername(string username)
        {
            return _repo.CheckUsername(username);
        }

        public string GetPassword(string username)
        {
            return _repo.GetPassword(username);
        }

        public string GetRole(string username)
        {
            return _repo.GetRole(username);
        }

        public string Hash(string username, string password)
        {
            string salt = _repo.GetSalt(username);
            return Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(password + salt)));
        }

        public void CreateAccount(string username, string password)
        {
            var saltBytes = new byte[16];
            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetNonZeroBytes(saltBytes);
            }
            string salt = Convert.ToBase64String(saltBytes);
            string hash = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(password + salt)));
            _repo.StoreAccount(username, hash, salt);
        }
    }
}