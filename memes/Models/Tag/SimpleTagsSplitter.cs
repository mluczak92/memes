using System;
using System.Collections.Generic;
using System.Linq;

namespace memes.Models {
    public class SimpleTagsSplitter : ITagsSplitter {
        public ICollection<PostTagRelation> Split(string tagsString) {
            return tagsString?.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Distinct()
                .Select(x => new PostTagRelation() {
                    Tag = new Tag() {
                        Value = x
                    }
                }).ToList();
        }
    }
}
