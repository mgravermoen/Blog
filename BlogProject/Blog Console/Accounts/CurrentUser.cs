namespace BlogProject
{
    public class CurrentUser : ICurrentUser
    {

        public string _username { get; private set; }

        public void SetUser(string username)
        {
            if (String.IsNullOrWhiteSpace(username))
            {
                return;
            }
            _username = username;
        }

        public string GetUser()
        {
            return _username;
        }
    }
}