using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace memes.Models {
    public class Post {
        [Required(AllowEmptyStrings = false, ErrorMessage = "title can not be empty")]
        [MinLength(5, ErrorMessage = "title has to be at least 5 characters")]
        public string Title { get; set; }

        [MaxLength(200, ErrorMessage = "description has to be at most 200 characters")]
        public string Description { get; set; }

        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = "maximum allowed file size is 1mb")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg" }, ErrorMessage = "only .jpg and .jpeg files are allowed")]
        public IFormFile Image { get; set; }

        public string ImageName { get; set; }
    }
}
