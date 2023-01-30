using AutoMapper;
using HeThongQuanLyTaiLieuDienTu_API.Data.DTOs;
using HeThongQuanLyTaiLieuDienTu_API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeThongQuanLyTaiLieuDienTu_API.Controllers
{
    [Authorize]
    public class UserController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // GET: Dữ liệu 1 người dùng bằng tên đăng nhập
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return await _userRepository.GetMemberAsync(username);
        }

        // GET: Dữ liệu toàn bộ người dùng
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            return Ok(await _userRepository.GetMembersAsync());
        }
    }
}