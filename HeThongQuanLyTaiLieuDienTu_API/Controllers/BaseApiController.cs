using HeThongQuanLyTaiLieuDienTu_API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace HeThongQuanLyTaiLieuDienTu_API.Controllers
{
    [ApiController]
    [Route("edmslab/api/[controller]")]
    [ServiceFilter(typeof(LogUserActivity))]
    public class BaseApiController : ControllerBase
    {
    }
}