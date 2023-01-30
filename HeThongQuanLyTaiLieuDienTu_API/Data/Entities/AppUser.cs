namespace HeThongQuanLyTaiLieuDienTu_API.Data.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string HoVaTen { get; set; }
        public DateTime NgayThangNamSinh { get; set; }
        public string DiaChi { get; set; }
        public bool GioiTinh { get; set; }
        public string SoCMND { get; set; }
        public DateTime NgayCapCMND { get; set; }
        public DateTime NgayKhoiTao { get; set; } = DateTime.Now;
        public DateTime NgayTruyCap { get; set; } = DateTime.Now;

        public ICollection<Photo> Photos { get; set; }
    }
}