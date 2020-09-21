using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace memes.Models {
    public class Tag {
        public int Id { get; set; }
        public string Value { get; set; }
        public ICollection<PostTagRelation> PostsRelations { get; set; }
    }
}
