using System.ComponentModel.DataAnnotations.Schema;

namespace HeThongQuanLyTaiLieuDienTu_API.Data.DTOs
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }

        [NotMapped] public bool IsRememberMe { get; set; }
    }
}