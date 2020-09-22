using System.Collections.Generic;

namespace memes.Models {
    public class PostViewModel {
        public IEnumerable<Post> Posts { get; set; }
        public string CurrentTag { get; set; }
        public int CurrentPage { get; set; }
    }
}
