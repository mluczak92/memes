using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace memes.Models {
    public class MaxFileSizeAttribute : ValidationAttribute {
        int maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize) {
            this.maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            IFormFile file = value as IFormFile;
            if (file != null) {
                if (file.Length > maxFileSize) {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
