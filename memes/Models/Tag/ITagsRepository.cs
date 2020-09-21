using System.Linq;

namespace memes.Models {
    public interface ITagsRepository {
        public IQueryable<Tag> Tags { get; }
    }
}
