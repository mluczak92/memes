using Slugify;

namespace memes.Models {
    public class SluggifySlugger : ISluggingService {
        public string Slug(string arg) {
            return new SlugHelper().GenerateSlug(arg);
        }
    }
}
