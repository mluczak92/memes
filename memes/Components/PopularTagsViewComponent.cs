using memes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Linq;

namespace memes.Components {
    public class PopularTagsViewComponent : ViewComponent {
        private ITagsRepository repo;

        public PopularTagsViewComponent(ITagsRepository repo) {
            this.repo = repo;
        }

        public IViewComponentResult Invoke() {
            ViewBag.CurrentTag = RouteData?.Values["tag"];
            return View(repo.Tags
                .Include(x => x.PostsRelations)
                .OrderByDescending(x => x.PostsRelations.Count)
                .ThenBy(x => x.Value)
                .Take(50)
                .Select(x => new TopTagVm() {
                    Value = x.Value,
                    Count = x.PostsRelations.Count
                }).ToArray());
        }
    }
}
