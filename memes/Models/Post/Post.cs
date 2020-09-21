using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace memes.Models {
    public class Post {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "title can not be empty")]
        [MinLength(5, ErrorMessage = "title has to be at least 5 characters")]
        [MaxLength(50, ErrorMessage = "title has to be at most 50 characters")]
        public string Title { get; set; }

        [NotMapped]
        [Required]
        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = "maximum allowed file size is 1mb")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg" }, ErrorMessage = "only .jpg and .jpeg files are allowed")]
        public IFormFile Image { get; set; }

        public string ImageName { get; set; }

        [MaxLength(200, ErrorMessage = "description has to be at most 200 characters")]
        public string Description { get; set; }

        [NotMapped]
        [MaxLength(200, ErrorMessage = "tags has to be at most 200 characters")]
        public string TagsString { get; set; }

        public ICollection<PostTagRelation> TagsRealtions { get; set; }
    }
}
