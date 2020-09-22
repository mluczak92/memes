using System.Linq;

namespace memes.Models {
    public class MemesSeeder {
        IPostsRepository postsRepo;
        ITagsSplitter splitter;

        public MemesSeeder(IPostsRepository postsRepo, ITagsSplitter splitter) {
            this.postsRepo = postsRepo;
            this.splitter = splitter;
        }

        public void Seed() {
            if (postsRepo.Posts.Any())
                return;

            for (int i = 0; i < 100; i++) {
                Post tmp = new Post() {
                    Title = "smieszny kot",
                    Description = "to jest smieszny obrazek z kotem",
                    ImageName = "default.jpg",
                    TagsString = $"cat{i % 2} kot{i % 3} smiesznykotek{i % 5}"
                };
                tmp.TagsRealtions = splitter.Split(tmp.TagsString);
                postsRepo.AddAsync(tmp).Wait();
            }
        }
    }
}
