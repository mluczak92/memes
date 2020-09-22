using System.Linq;

namespace memes.Models {
    public class MemesSeeder {
        IPostsRepository postsRepo;

        public MemesSeeder(IPostsRepository postsRepo) {
            this.postsRepo = postsRepo;
        }

        public void Seed() {
            if (postsRepo.Posts.Any())
                return;

            for (int i = 0; i < 100; i++) {
                Post tmp = new Post() {
                    Title = "  całkiem  smieszny kot  ",
                    Description = "to jest smieszny obrazek z kotem",
                    ImageName = "default.jpg",
                    TagsString = $"cat{i % 2} kot{i % 3} smiesznykotek{i % 5}"
                };
                postsRepo.AddAsync(tmp).Wait();
            }
        }
    }
}
