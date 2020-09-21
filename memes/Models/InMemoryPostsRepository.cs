using System.Collections.Generic;
using System.Linq;

namespace memes.Models {
    public class InMemoryPostsRepository : IPostsRepository {
        List<Post> posts = new List<Post>() {
            new Post() {
                Title = "Raz",
                Description = "Opis pierwszy",
                ImageName = "default.jpg",
                Tags = new List<Tag>() {
                    new Tag() {
                        Value = "koteł"
                    },
                    new Tag() {
                        Value = "cat"
                    }
                }
            },
            new Post() {
                Title = "Raz",
                Description = "Opis pierwszy",
                ImageName = "default.jpg",
                Tags = new List<Tag>() {
                    new Tag() {
                        Value = "koteł"
                    },
                    new Tag() {
                        Value = "cat"
                    }
                }
            },
            new Post() {
                Title = "Raz",
                Description = "Opis pierwszy",
                ImageName = "default.jpg",
                Tags = new List<Tag>() {
                    new Tag() {
                        Value = "koteł"
                    },
                    new Tag() {
                        Value = "cat"
                    }
                }
            },
            new Post() {
                Title = "Raz",
                Description = "Opis pierwszy",
                ImageName = "default.jpg",
                Tags = new List<Tag>() {
                    new Tag() {
                        Value = "koteł"
                    },
                    new Tag() {
                        Value = "cat"
                    }
                }
            }
        };

        public IQueryable<Post> Posts => posts.AsQueryable();

        public void Add(Post post) {
            posts.Add(post);
        }
    }
}
