using System;
using System.Collections.Generic;
using System.Linq;

namespace memes.Models {
    public class EFUniqueTagsSplitter : ITagsSplitter {
        ITagsRepository repo;

        public EFUniqueTagsSplitter(ITagsRepository repo) {
            this.repo = repo;
        }

        public ICollection<PostTagRelation> Split(string tagsString) {
            IEnumerable<string> distinctTags = tagsString?.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Distinct();

            List<PostTagRelation> rels = distinctTags.Select(x => {
                return new PostTagRelation() {
                    TagId = repo.Tags.SingleOrDefault(y => y.Value == x)?.Id ?? 0,
                    Tag = new Tag() {
                        Value = x
                    }
                };
            }).ToList();

            foreach (PostTagRelation rel in rels.Where(x => x.TagId != 0)) {
                rel.Tag = null;
            }

            return rels;
        }
    }
}
