using HeThongQuanLyTaiLieuDienTu_API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace HeThongQuanLyTaiLieuDienTu_API.Data
{
    public static class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (await userManager.Users.AnyAsync()) return;
            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

            var roles = new List<AppRole>
            {
                new AppRole { Name = "Admin" },
                new AppRole { Name = "Member" },
                new AppRole { Name = "Moderator" },
                new AppRole { Name = "Client" },
            };
            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();
                await userManager.CreateAsync(user, "Password123@");
                await userManager.AddToRoleAsync(user, "Member");
            }

            var admin = new AppUser
            {
                UserName = "admin"
            };
            await userManager.CreateAsync(admin, "Password123@");
            await userManager.AddToRolesAsync(admin, new[] { "Admin", "Moderator" });

            var client = new AppUser
            {
                UserName = "client"
            };
            await userManager.CreateAsync(client, "Password123@");
            await userManager.AddToRoleAsync(client, "Client");
        }
    }
}