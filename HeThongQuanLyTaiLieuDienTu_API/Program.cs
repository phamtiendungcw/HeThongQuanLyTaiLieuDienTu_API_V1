using HeThongQuanLyTaiLieuDienTu_API.Data;
using HeThongQuanLyTaiLieuDienTu_API.Data.Entities;
using HeThongQuanLyTaiLieuDienTu_API.Extensions;
using HeThongQuanLyTaiLieuDienTu_API.Middleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration); // Application extensions services
builder.Services.AddIdentityServices(builder.Configuration); // Identity extensions services
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Authorization", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() {
        In = ParameterLocation.Header,
        Description = "Hãy nhập token người dùng",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();
//app.UseStaticFiles();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try {
    var context = services.GetRequiredService<DataContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
    await context.Database.MigrateAsync();
    await Seed.SeedUsers(userManager, roleManager);
}
catch (Exception ex) {
    var logger = services.GetService<ILogger<Program>>();
    logger.LogError(ex, "Đã xảy ra lỗi trong quá trình xử lý dữ liệu Seed");
}

app.Run();