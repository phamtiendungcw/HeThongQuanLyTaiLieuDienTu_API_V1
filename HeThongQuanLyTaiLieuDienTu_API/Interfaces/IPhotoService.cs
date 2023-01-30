using CloudinaryDotNet.Actions;

namespace HeThongQuanLyTaiLieuDienTu_API.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}