namespace BlogProject
{
    public interface IAccountService
    {

        public bool CheckUsername(string username);

        public string GetPassword(string username);

        public string GetRole(string username);

        public string Hash(string username, string password);

        public void CreateAccount(string username, string password);
    }
}