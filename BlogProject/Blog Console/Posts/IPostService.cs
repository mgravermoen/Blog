namespace BlogProject
{
    public interface IPostService
    {

        public void StorePost(Post post);

        public Post ReadPost(int id);

        public List<Post> ListTitles();

        public List<Post> ListSearchedTitles(string searchTerm);

        public void DeletePost(int id);

        public void updatePost(Post post);
    }
}