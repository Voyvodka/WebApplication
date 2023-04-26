using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapplication.dataaccess.Migrations
{
    public partial class mig_menutablesredesigned1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuModuleMenus");

            migrationBuilder.CreateTable(
                name: "ModuleMenus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    MenuModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ModuleMenus_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "MenuModuleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleMenus_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleMenus_MenuId",
                table: "ModuleMenus",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleMenus_MenuModuleId",
                table: "ModuleMenus",
                column: "MenuModuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleMenus");

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
    }
}
