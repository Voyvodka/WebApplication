using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable
namespace webapplication.dataaccess.Migrations
{
    public partial class mig_menutablesredesigned2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //    name: "FK_ModuleMenus_MenuModules_MenuModuleId",
            //    table: "ModuleMenus");
            // migrationBuilder.DropTable(
            //     name: "MenuModules");
            // migrationBuilder.CreateTable(
            //     name: "Modules",
            //     columns: table => new
            //     {
            //         ModuleId = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         ModuleText = table.Column<string>(type: "longtext", nullable: false)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         ModuleIconPath = table.Column<string>(type: "longtext", nullable: false)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         Passive = table.Column<bool>(type: "tinyint(1)", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Modules", x => x.ModuleId);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");
            // migrationBuilder.AddForeignKey(
            //     name: "FK_ModuleMenus_Modules_ModuleId",
            //     table: "ModuleMenus",
            //     column: "ModuleId",
            //     principalTable: "Modules",
            //     principalColumn: "ModuleId",
            //     onDelete: ReferentialAction.Cascade);
            // migrationBuilder.RenameColumn(
            //     name: "MenuModuleId",
            //     table: "ModuleMenus",
            //     newName: "ModuleId");
            // migrationBuilder.RenameIndex(
            //     name: "IX_ModuleMenus_MenuModuleId",
            //     table: "ModuleMenus",
            //     newName: "IX_ModuleMenus_ModuleId");
            migrationBuilder.AddColumn<int>(
                name: "ModuleMenuId",
                table: "ModuleMenus",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
            migrationBuilder.AddPrimaryKey(
                name: "PK_ModuleMenus",
                table: "ModuleMenus",
                column: "ModuleMenuId");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleMenus_Modules_ModuleId",
                table: "ModuleMenus");
            migrationBuilder.DropTable(
                name: "Modules");
            migrationBuilder.DropPrimaryKey(
                name: "PK_ModuleMenus",
                table: "ModuleMenus");
            migrationBuilder.DropColumn(
                name: "ModuleMenuId",
                table: "ModuleMenus");
            migrationBuilder.RenameColumn(
                name: "ModuleId",
                table: "ModuleMenus",
                newName: "MenuModuleId");
            migrationBuilder.RenameIndex(
                name: "IX_ModuleMenus_ModuleId",
                table: "ModuleMenus",
                newName: "IX_ModuleMenus_MenuModuleId");
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
            migrationBuilder.CreateTable(
                name: "MenuModules",
                columns: table => new
                {
                    MenuModuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MenuModuleIconPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MenuModuleText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Passive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuModules", x => x.MenuModuleId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
            migrationBuilder.AddForeignKey(
                name: "FK_ModuleMenus_MenuModules_MenuModuleId",
                table: "ModuleMenus",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "MenuModuleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
