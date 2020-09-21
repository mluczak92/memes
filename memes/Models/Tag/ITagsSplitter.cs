using System.Collections.Generic;

namespace memes.Models {
    public interface ITagsSplitter {
        public ICollection<PostTagRelation> Split(string tagsString);
    }
}
