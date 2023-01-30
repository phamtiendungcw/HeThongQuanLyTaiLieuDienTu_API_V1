namespace HeThongQuanLyTaiLieuDienTu_API.Data.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string HoVaTen { get; set; }
        public string PhotoUrl { get; set; }
        public int Tuoi { get; set; }
        public DateTime NgayThangNamSinh { get; set; }
        public string DiaChi { get; set; }
        public bool GioiTinh { get; set; }
        public string SoCMND { get; set; }
        public DateTime NgayCapCMND { get; set; }
        public DateTime NgayKhoiTao { get; set; }
        public DateTime NgayTruyCap { get; set; }

        public ICollection<PhotoDto> Photos { get; set; }
    }
}
