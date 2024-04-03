using Microsoft.AspNetCore.Http;

namespace Pyramids.Core.IServices
{
    public interface IBlobService
    {
        Task<string> UploadFileAsync(IFormFile file);
        Task<bool> RemoveFileAsync(string blobName);
        Task<Stream> GetFileAsync(string blobName);
    }
}
