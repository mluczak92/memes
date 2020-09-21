using System.Collections.Generic;

namespace memes.Models {
    public interface ITagsSplitter {
        public IEnumerable<Tag> Split(string tagsString);
    }
}
