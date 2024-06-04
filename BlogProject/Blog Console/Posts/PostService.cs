namespace BlogProject
{
    public class PostService : IPostService
    {

        private readonly IPostRepo _repo;

        public PostService(IPostRepo repo)
        {
            _repo = repo;
        }


        public void StorePost(Post post)
        {
            _repo.AddPost(post);
        }

        public Post ReadPost(int id)
        {
            return _repo.GetPost(id);
        }

        public List<Post> ListTitles()
        {
            return _repo.CreateList();
        }

        public List<Post> ListSearchedTitles(string searchTerm)
        {
            return _repo.CreateSearchedList(searchTerm);
        }

        public void DeletePost(int id)
        {
            _repo.DeleteKey(id);
        }

        public void updatePost(Post post) 
        {
            _repo.UpdateKey(post);
        }
    }
}