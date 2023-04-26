using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapplication.dataaccess.Migrations
{
    public partial class mig_menutablesredesigned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuHeaders_MenuModules_MenuModuleId",
                table: "MenuHeaders");

            migrationBuilder.DropIndex(
                name: "IX_MenuHeaders_MenuModuleId",
                table: "MenuHeaders");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "MenuHeaders");

            migrationBuilder.CreateTable(
                name: "MenuModuleMenus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    MenuModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_MenuModuleMenus_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "MenuModuleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuModuleMenus_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MenuModuleMenus_MenuId",
                table: "MenuModuleMenus",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuModuleMenus_MenuModuleId",
                table: "MenuModuleMenus",
                column: "MenuModuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuModuleMenus");

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "MenuHeaders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MenuHeaders_MenuModuleId",
                table: "MenuHeaders",
                column: "MenuModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuHeaders_MenuModules_MenuModuleId",
                table: "MenuHeaders",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "MenuModuleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
