using BlogProject;

namespace BlogPostTests {

    public class MockPostService : IPostService
    {
        public List<Post> _list = new List<Post>();

        public int DeleteId = default;

        public void DeletePost(int id)
        {
            DeleteId = id;
        }

        public List<Post> ListTitles()
        {
            return _list;
        }

        public Post ReadPost(int id)
        {
            return _list[id - 1];
        }

        public void StorePost(Post post)
        {
            _list.Add(post);
        }

        public void updatePost(Post post)
        {
            _list[post.KeyID - 1] = post;
        }
    }

}