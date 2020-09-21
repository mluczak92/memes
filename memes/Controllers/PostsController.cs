using memes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace memes.Controllers {
    public class PostsController : Controller {
        IPostsRepository postsRepo;
        IImageUploader imageUploader;
        ITagsSplitter tagsSplitter;

        public PostsController(IPostsRepository postsRepo, IImageUploader imageUploader,
            ITagsSplitter tagsSplitter) {
            this.postsRepo = postsRepo;
            this.imageUploader = imageUploader;
            this.tagsSplitter = tagsSplitter;
        }

        public ViewResult Index() {
            return View(postsRepo.Posts);
        }

        public ViewResult New() {
            return View(new Post());
        }

        [HttpPost]
        public async Task<IActionResult> New(Post post) {
            if (ModelState.IsValid) {
                post.ImageName = await imageUploader.UploadAndGetName(post.Image);
                post.Tags = tagsSplitter.Split(post.TagsString);
                postsRepo.Add(post);
                return RedirectToAction("Index");
            } else {
                return View();
            }
        }
    }
}
