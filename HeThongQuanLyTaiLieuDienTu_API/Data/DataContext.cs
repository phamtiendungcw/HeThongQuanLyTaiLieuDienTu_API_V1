using HeThongQuanLyTaiLieuDienTu_API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeThongQuanLyTaiLieuDienTu_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
    }
}
