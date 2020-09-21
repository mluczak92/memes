using memes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace memes.Controllers {
    public class PostsController : Controller {
        IPostsRepository postsRepo;

        public PostsController(IPostsRepository postsRepo) {
            this.postsRepo = postsRepo;
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
                await postsRepo.Add(post);
                return RedirectToAction("Index");
            } else {
                return View();
            }
        }
    }
}
