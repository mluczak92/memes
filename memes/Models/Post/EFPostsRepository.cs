using System.Linq;
using System.Threading.Tasks;

namespace memes.Models {
    public class EFPostsRepository : IPostsRepository {
        MemesContext dbContext;

        public EFPostsRepository(MemesContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task Add(Post post) {
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();
        }

        public IQueryable<Post> Posts => dbContext.Posts;
    }
}
