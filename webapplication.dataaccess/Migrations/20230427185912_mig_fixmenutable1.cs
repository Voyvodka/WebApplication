using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable
namespace webapplication.dataaccess.Migrations
{
    public partial class mig_fixmenutable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Menus_ApplicationRoleId1",
                table: "Menus");
            migrationBuilder.DropColumn(
                name: "ApplicationRoleId",
                table: "Menus");
            migrationBuilder.DropColumn(
                name: "ApplicationRoleId1",
                table: "Menus");
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationRoleId",
                table: "Menus",
                type: "int",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "ApplicationRoleId1",
                table: "Menus",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
            migrationBuilder.CreateIndex(
                name: "IX_Menus_ApplicationRoleId1",
                table: "Menus",
                column: "ApplicationRoleId1");
        }
    }
}
