namespace HeThongQuanLyTaiLieuDienTu_API.Data.DTOs {

    public class DocumentUpdateDto {

        public string Title { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IFormFile Content { get; set; }
    }
}