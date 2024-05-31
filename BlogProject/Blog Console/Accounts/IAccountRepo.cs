namespace BlogProject
{
    public interface IAccountRepo
    {

        public bool CheckUsername(string username);

        public string GetPassword(string username);

        public string GetRole(string username);

        public string GetSalt(string username);

        public void StoreAccount(string username, string hash, string salt);
    }
}