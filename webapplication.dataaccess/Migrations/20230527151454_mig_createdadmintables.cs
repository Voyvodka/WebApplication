using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable
namespace webapplication.dataaccess.Migrations
{
    public partial class mig_createdadmintables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminMenuHeaders",
                columns: table => new
                {
                    AdminMenuHeaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AdminMenuHeaderText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdminMenuHeaderIconPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Passive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminMenuHeaders", x => x.AdminMenuHeaderId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
            migrationBuilder.CreateTable(
                name: "AdminModules",
                columns: table => new
                {
                    AdminModuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AdminModuleText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdminModuleIconPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Passive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminModules", x => x.AdminModuleId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
            migrationBuilder.CreateTable(
                name: "AdminMenus",
                columns: table => new
                {
                    AdminMenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AdminMenuText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdminMenuKeyword = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdminMenuHref = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdminMenuIconPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdminMenuHeaderId = table.Column<int>(type: "int", nullable: false),
                    ApplicationRoleId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Passive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminMenus", x => x.AdminMenuId);
                    table.ForeignKey(
                        name: "FK_AdminMenus_AdminMenuHeaders_AdminMenuHeaderId",
                        column: x => x.AdminMenuHeaderId,
                        principalTable: "AdminMenuHeaders",
                        principalColumn: "AdminMenuHeaderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminMenus_AspNetRoles_ApplicationRoleId",
                        column: x => x.ApplicationRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");
            migrationBuilder.CreateTable(
                name: "AdminModuleMenus",
                columns: table => new
                {
                    AdminModuleMenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AdminMenuId = table.Column<int>(type: "int", nullable: false),
                    AdminModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminModuleMenus", x => x.AdminModuleMenuId);
                    table.ForeignKey(
                        name: "FK_AdminModuleMenus_AdminMenus_AdminMenuId",
                        column: x => x.AdminMenuId,
                        principalTable: "AdminMenus",
                        principalColumn: "AdminMenuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminModuleMenus_AdminModules_AdminModuleId",
                        column: x => x.AdminModuleId,
                        principalTable: "AdminModules",
                        principalColumn: "AdminModuleId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
            migrationBuilder.CreateIndex(
                name: "IX_AdminMenus_AdminMenuHeaderId",
                table: "AdminMenus",
                column: "AdminMenuHeaderId");
            migrationBuilder.CreateIndex(
                name: "IX_AdminMenus_ApplicationRoleId",
                table: "AdminMenus",
                column: "ApplicationRoleId");
            migrationBuilder.CreateIndex(
                name: "IX_AdminModuleMenus_AdminMenuId",
                table: "AdminModuleMenus",
                column: "AdminMenuId");
            migrationBuilder.CreateIndex(
                name: "IX_AdminModuleMenus_AdminModuleId",
                table: "AdminModuleMenus",
                column: "AdminModuleId");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminModuleMenus");
            migrationBuilder.DropTable(
                name: "AdminMenus");
            migrationBuilder.DropTable(
                name: "AdminModules");
            migrationBuilder.DropTable(
                name: "AdminMenuHeaders");
        }
    }
}
