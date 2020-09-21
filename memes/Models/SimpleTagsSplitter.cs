using System;
using System.Collections.Generic;
using System.Linq;

namespace memes.Models {
    public class SimpleTagsSplitter : ITagsSplitter {
        public IEnumerable<Tag> Split(string tagsString) {
            return tagsString?.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Distinct()
                .Select(x => new Tag() { Value = x });
        }
    }
}
