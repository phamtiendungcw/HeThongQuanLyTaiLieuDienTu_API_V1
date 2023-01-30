using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeThongQuanLyTaiLieuDienTu_API.Data.Migrations
{
    public partial class ExtendedUserEntityV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");
        }
    }
}
