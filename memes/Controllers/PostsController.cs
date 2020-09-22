﻿using memes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace memes.Controllers {
    public class PostsController : Controller {
        IPostsRepository postsRepo;
        int pageSize = 10;

        public PostsController(IPostsRepository postsRepo) {
            this.postsRepo = postsRepo;
        }

        public async Task<IActionResult> Index(string tag = "", int page = 1) {
            ViewBag.CurrentTag = RouteData?.Values["tag"];

            IQueryable<Post> query = postsRepo.Posts
                .Include(x => x.TagsRealtions)
                    .ThenInclude(x => x.Tag)
                .Where(x => tag == "" ? true : x.TagsRealtions.Any(y => y.Tag.Value == tag))
                .OrderByDescending(x => x.Id);


            IEnumerable<Post> posts = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

            return View(new PostViewModel() {
                Posts = posts,
                CurrentTag = tag,
                CurrentPage = page,
                PageSize = pageSize,
                PostsCount = await query.CountAsync()
        });
        }

        public ViewResult New() {
            return View(new Post());
        }

        [HttpPost]
        public async Task<IActionResult> New(Post post) {
            if (ModelState.IsValid) {
                await postsRepo.AddAsync(post);
                return RedirectToAction("Index");
            } else {
                return View();
            }
        }

        public async Task<IActionResult> Single(int id, string slug) {
            Post post = await postsRepo.Posts
                .Include(x => x.TagsRealtions)
                    .ThenInclude(x => x.Tag)
                .SingleOrDefaultAsync(x => x.Id == id && x.SluggedTitle == slug);

            if (post == null)
                return NotFound();

            return View(post);
        }
    }
}
