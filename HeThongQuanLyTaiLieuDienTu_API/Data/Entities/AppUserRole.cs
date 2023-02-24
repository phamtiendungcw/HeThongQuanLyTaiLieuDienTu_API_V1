using Microsoft.AspNetCore.Identity;

namespace HeThongQuanLyTaiLieuDienTu_API.Data.Entities {

    public class AppUserRole : IdentityUserRole<int> {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
    }
}