namespace BlogProject
{
    public interface ICurrentUser
    {
        public void SetUser(string username);

        public string GetUser();
    }
}