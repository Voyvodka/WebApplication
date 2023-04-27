using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapplication.dataaccess.Migrations
{
    public partial class mig_fixmenutable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationRoleId",
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
                name: "IX_Menus_ApplicationRoleId",
                table: "Menus",
                column: "ApplicationRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_AspNetRoles_ApplicationRoleId",
                table: "Menus",
                column: "ApplicationRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_AspNetRoles_ApplicationRoleId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_ApplicationRoleId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "ApplicationRoleId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");
        }
    }
}
