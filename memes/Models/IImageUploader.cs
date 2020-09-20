using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace memes.Models {
    public interface IImageUploader {
        Task<string> UploadAndGetName(IFormFile file);
    }
}
