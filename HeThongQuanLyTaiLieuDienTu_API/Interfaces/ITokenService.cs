using HeThongQuanLyTaiLieuDienTu_API.Data.Entities;

namespace HeThongQuanLyTaiLieuDienTu_API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
