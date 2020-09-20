using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace memes.Models {
    public class AllowedExtensionsAttribute : ValidationAttribute {
        string[] extensions;

        public AllowedExtensionsAttribute(string[] extensions) {
            this.extensions = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            IFormFile file = value as IFormFile;
            if (file != null) {
                string extension = Path.GetExtension(file.FileName);
                if (!extensions.Contains(extension.ToLower())) {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
