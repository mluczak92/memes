using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace memes.Models {
    public class SimpleImageUploader : IImageUploader {
        IWebHostEnvironment environment;

        public SimpleImageUploader(IWebHostEnvironment environment) {
            this.environment = environment;
        }

        public async Task<string> UploadAndGetName(IFormFile file) {
            if (file == null)
                return null;

            string uploadsPath = Path.Combine(environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsPath)) {
                Directory.CreateDirectory(uploadsPath);
            }

            string newFileName = Path.GetRandomFileName();
            newFileName = Path.ChangeExtension(newFileName, Path.GetExtension(file.FileName));

            string filePath = Path.Combine(uploadsPath, newFileName);
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create)) {
                await file.CopyToAsync(fileStream);
            }

            return newFileName;
        }
    }
}
