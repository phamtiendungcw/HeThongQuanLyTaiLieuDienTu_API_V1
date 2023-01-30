namespace HeThongQuanLyTaiLieuDienTu_API.Data.DTOs
{
    public class MemberUpdateDto
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string HoVaTen { get; set; }
        public DateTime NgayThangNamSinh { get; set; }
        public string DiaChi { get; set; }
        public bool GioiTinh { get; set; }
        public string SoCMND { get; set; }
        public DateTime NgayCapCMND { get; set; }
    }
}
