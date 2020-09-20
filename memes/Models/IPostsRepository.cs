using System.Linq;

namespace memes.Models {
    public interface IPostsRepository {
        IQueryable<Post> Posts { get; }
        void Add(Post post);
    }
}
