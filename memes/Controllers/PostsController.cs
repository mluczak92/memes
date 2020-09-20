using memes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace memes.Controllers {
    public class PostsController : Controller {
        IPostsRepository postsRepo;
        IImageUploader imageUploader;

        public PostsController(IPostsRepository postsRepo, IImageUploader imageUploader) {
            this.postsRepo = postsRepo;
            this.imageUploader = imageUploader;
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
                postsRepo.Add(post);
                return RedirectToAction("Index");
            } else {
                return View();
            }
        }
    }
}
