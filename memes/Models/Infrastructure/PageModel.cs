using System;

namespace memes.Models {
    public class PageModel {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public int PagesCount => Convert.ToInt32(Math.Ceiling(Count / (decimal)PageSize));
    }
}
