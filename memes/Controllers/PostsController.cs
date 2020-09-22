using memes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace memes.Controllers {
    public class PostsController : Controller {
        IPostsRepository postsRepo;
        IImageUploader imageUploader;
        ITagsSplitter tagsSplitter;
        int pageSize = 10;

        public PostsController(IPostsRepository postsRepo, IImageUploader imageUploader,
            ITagsSplitter tagsSplitter) {
            this.postsRepo = postsRepo;
            this.imageUploader = imageUploader;
            this.tagsSplitter = tagsSplitter;
        }

        public async Task<ViewResult> Index(string tag = "", int page = 1) {
            ViewBag.CurrentTag = RouteData?.Values["tag"];

            List<Post> result = await postsRepo.Posts
                .Include(x => x.TagsRealtions)
                .ThenInclude(x => x.Tag)
                .Where(x => tag == "" ||
                    x.TagsRealtions.Any(y => y.Tag.Value == tag))
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return View(new PostViewModel() {
                Posts = result,
                CurrentTag = tag,
                CurrentPage = page
            });
        }

        public ViewResult New() {
            return View(new Post());
        }

        [HttpPost]
        public async Task<IActionResult> New(Post post) {
            if (ModelState.IsValid) {
                post.ImageName = await imageUploader.UploadAndGetName(post.Image);
                post.TagsRealtions = tagsSplitter.Split(post.TagsString);
                await postsRepo.AddAsync(post);
                return RedirectToAction("Index");
            } else {
                return View();
            }
        }
    }
}
