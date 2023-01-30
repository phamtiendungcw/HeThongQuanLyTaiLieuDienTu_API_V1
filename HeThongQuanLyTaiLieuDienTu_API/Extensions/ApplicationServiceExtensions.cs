using HeThongQuanLyTaiLieuDienTu_API.Data;
using HeThongQuanLyTaiLieuDienTu_API.Helpers;
using HeThongQuanLyTaiLieuDienTu_API.Interfaces;
using HeThongQuanLyTaiLieuDienTu_API.Services;
using Microsoft.EntityFrameworkCore;

namespace HeThongQuanLyTaiLieuDienTu_API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            return services;
        }
    }
}
