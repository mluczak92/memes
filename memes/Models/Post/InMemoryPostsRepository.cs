using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace memes.Models {
    public class InMemoryPostsRepository : IPostsRepository {
        List<Post> posts = new List<Post>() {
            new Post() {
                Title = "Raz",
                Description = "Opis pierwszy",
                ImageName = "default.jpg",
                TagsRealtions = new List<PostTagRelation>() {
                    new PostTagRelation() {
                        Tag = new Tag() {
                            Value = "koteł"
                        }
                    },
                    new PostTagRelation() {
                        Tag = new Tag() {
                            Value = "tag"
                        }
                    }
                }
            },
            new Post() {
                Title = "Raz",
                Description = "Opis pierwszy",
                ImageName = "default.jpg",
                TagsRealtions = new List<PostTagRelation>() {
                    new PostTagRelation() {
                        Tag = new Tag() {
                            Value = "koteł"
                        }
                    },
                    new PostTagRelation() {
                        Tag = new Tag() {
                            Value = "tag"
                        }
                    }
                }
            },
            new Post() {
                Title = "Raz",
                Description = "Opis pierwszy",
                ImageName = "default.jpg",
                TagsRealtions = new List<PostTagRelation>() {
                    new PostTagRelation() {
                        Tag = new Tag() {
                            Value = "koteł"
                        }
                    },
                    new PostTagRelation() {
                        Tag = new Tag() {
                            Value = "tag"
                        }
                    }
                }
            }
        };

        public IQueryable<Post> Posts => posts.AsQueryable();

        public async Task Add(Post post) {
            posts.Add(post);
        }
    }
}
