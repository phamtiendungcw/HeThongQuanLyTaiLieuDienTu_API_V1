using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyTaiLieuDienTu_API.Data.DTOs
{
    public class RegisterDto
    {
        [Required] public string Username { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 4)]
        public string Password { get; set; }
    }
}