using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace scorecard_cbt.Interfaces
{
    public interface IImageService
    {
        Task<UploadResult> UploadAsync(IFormFile image);
    }
}
