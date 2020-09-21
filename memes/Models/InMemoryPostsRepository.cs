using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace memes.Models {
    public class InMemoryPostsRepository : IPostsRepository {
        IImageUploader imageUploader;
        ITagsSplitter tagsSplitter;
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

        public InMemoryPostsRepository(IImageUploader imageUploader, ITagsSplitter tagsSplitter) {
            this.imageUploader = imageUploader;
            this.tagsSplitter = tagsSplitter;
        }

        public IQueryable<Post> Posts => posts.AsQueryable();

        public async Task Add(Post post) {
            post.ImageName = await imageUploader.UploadAndGetName(post.Image);
            post.Tags = tagsSplitter.Split(post.TagsString);
            posts.Add(post);
        }
    }
}
