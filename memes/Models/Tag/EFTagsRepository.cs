using System.Linq;

namespace memes.Models {
    public class EFTagsRepository : ITagsRepository {
        MemesContext dbContext;

        public EFTagsRepository(MemesContext dbContext) {
            this.dbContext = dbContext;
        }

        public IQueryable<Tag> Tags => dbContext.Tags;
    }
}
