using System.Linq;
using System.Threading.Tasks;

namespace memes.Models {
    public interface IPostsRepository {
        IQueryable<Post> Posts { get; }
        Task Add(Post post);
    }
}
