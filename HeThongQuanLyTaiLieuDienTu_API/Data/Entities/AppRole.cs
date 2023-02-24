using Microsoft.AspNetCore.Identity;

namespace HeThongQuanLyTaiLieuDienTu_API.Data.Entities {

    public class AppRole : IdentityRole<int> {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}