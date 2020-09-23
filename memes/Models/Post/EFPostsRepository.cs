using System.Linq;
using System.Threading.Tasks;

namespace memes.Models {
    public class EFPostsRepository : IPostsRepository {
        MemesContext dbContext;
        IImageUploader imageUploader;
        ITagsSplitter tagsSplitter;
        ISluggingService slugger;

        public EFPostsRepository(MemesContext dbContext, IImageUploader imageUploader,
            ITagsSplitter tagsSplitter, ISluggingService slugger) {
            this.dbContext = dbContext;
            this.imageUploader = imageUploader;
            this.tagsSplitter = tagsSplitter;
            this.slugger = slugger;
        }

        public IQueryable<Post> Posts => dbContext.Posts;

        public async Task AddAsync(Post post) {
            post.ImageName = await imageUploader.UploadAndGetName(post.Image);
            post.TagsRealtions = tagsSplitter.Split(post.TagsString);
            post.SluggedTitle = slugger.Slug(post.Title);
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();
        }
    }
}
