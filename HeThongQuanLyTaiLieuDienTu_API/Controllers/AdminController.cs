using HeThongQuanLyTaiLieuDienTu_API.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeThongQuanLyTaiLieuDienTu_API.Controllers {

    public class AdminController : BaseApiController {
        private readonly UserManager<AppUser> _userManager;

        public AdminController(UserManager<AppUser> userManager) {
            _userManager = userManager;
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("edit-roles/{username}")]
        public async Task<ActionResult> EditRoles([FromRoute] string username, [FromQuery] string roles) {
            if (string.IsNullOrEmpty(roles)) return BadRequest("Bạn phải chọn ít nhất 1 quyền hạn");
            var selectRoles = roles.Split(",").ToArray();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return NotFound();
            var userRoles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.AddToRolesAsync(user, selectRoles.Except(userRoles));
            if (!result.Succeeded) return BadRequest("Không thể thêm quyền hạn");

            var result1 = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectRoles));
            if (!result1.Succeeded) return BadRequest("Không thể xóa khỏi vai trò");

            return Ok(await _userManager.GetRolesAsync(user));
        }

        [Authorize(Policy = "ModeratePhotoRole")]
        [HttpGet("photos-to-moderate")]
        public ActionResult GetPhotosForModeration() {
            return Ok("Thông tin chỉ dành cho quản trị viên và người điều hành");
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("users-with-roles")]
        public async Task<ActionResult> GetUsersWithRoles() {
            var users = await _userManager.Users
                .OrderBy(u => u.UserName)
                .Select(u => new {
                    u.Id,
                    Username = u.UserName,
                    Roles = u.UserRoles.Select(r => r.Role.Name).ToList()
                }).ToListAsync();

            return Ok(users);
        }
    }
}