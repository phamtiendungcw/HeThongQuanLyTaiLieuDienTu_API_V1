using HeThongQuanLyTaiLieuDienTu_API.Extensions;
using HeThongQuanLyTaiLieuDienTu_API.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HeThongQuanLyTaiLieuDienTu_API.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            if (!(resultContext.HttpContext.User.Identity == null || resultContext.HttpContext.User.Identity.IsAuthenticated)) return;

            var username = resultContext.HttpContext.User.GetUsername();

            var repository = resultContext.HttpContext.RequestServices.GetRequiredService<IUserRepository>();
            var user = await repository.GetUserByUsernameAsync(username);
            user.NgayTruyCap = DateTime.Now;
            await repository.SaveAllAsync();
        }
    }
}
