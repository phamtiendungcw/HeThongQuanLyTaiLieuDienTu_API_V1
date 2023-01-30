namespace HeThongQuanLyTaiLieuDienTu_API.Errors
{
    public class ApiException
    {
        public ApiException(int statusCode, string message, string details)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }

        private string Details { get; set; }
        private string Message { get; set; }
        private int StatusCode { get; set; }
    }
}