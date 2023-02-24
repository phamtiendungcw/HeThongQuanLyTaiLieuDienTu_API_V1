using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeThongQuanLyTaiLieuDienTu_API.Data.Migrations {

    public partial class ExtendedUserEntityV2 : Migration {

        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.AddColumn<string>(
                name: "NoiCapCMND",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropColumn(
                name: "NoiCapCMND",
                table: "Users");
        }
    }
}