using Microsoft.AspNetCore.Identity;

namespace HeThongQuanLyTaiLieuDienTu_API.Data.Entities {

    public class AppUser : IdentityUser<int> {
        public string Phone { get; set; }
        public string HoVaTen { get; set; }
        public DateTime NgayThangNamSinh { get; set; }
        public string DiaChi { get; set; }
        public bool GioiTinh { get; set; }
        public string SoCMND { get; set; }
        public string NoiCapCMND { get; set; }
        public DateTime NgayCapCMND { get; set; }
        public DateTime NgayKhoiTao { get; set; } = DateTime.Now;
        public DateTime NgayTruyCap { get; set; } = DateTime.Now;

        public ICollection<Photo> Photos { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}