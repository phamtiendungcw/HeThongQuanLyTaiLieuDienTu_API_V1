namespace HeThongQuanLyTaiLieuDienTu_API.Data.DTOs
{
    public class DocumentUpdateDto
    {
        public string Name { get; set; }

        public IFormFile Content { get; set; }
    }
}
