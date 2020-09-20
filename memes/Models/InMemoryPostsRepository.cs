using System.Collections.Generic;
using System.Linq;

namespace memes.Models {
    public class InMemoryPostsRepository : IPostsRepository {
        List<Post> posts = new List<Post>() {
            new Post() { Title = "Raz", Description = "Opis pierwszy", ImageName = "1asn0ykh.nfy.jpg" },
            new Post() { Title = "Dwa Dwa Dwa Dwa", ImageName = "1asn0ykh.nfy.jpg" },
            new Post() { Title = "Trzy", Description = "Opis trzeci trzeci, trzeci, trzecitrzecitrzecitrzeci trzeci trzeci", ImageName = "1asn0ykh.nfy.jpg" },
            new Post() { Title = "Cztery Cztery", Description = "Opis czwarty", ImageName = "1asn0ykh.nfy.jpg" },
        };

        public IQueryable<Post> Posts => posts.AsQueryable();

        public void Add(Post post) {
            posts.Add(post);
        }
    }
}
