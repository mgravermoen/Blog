namespace BlogProject
{
    public interface IPostRepo
    {
        public void AddPost(Post post);

        public Post GetPost(int id);

        public List<Post> CreateList();

        public void DeleteKey(int id);

        public void UpdateKey(Post post);
    }
}