using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapplication.dataaccess.Migrations
{
    public partial class mig_createdrolegroupandrolegrouprolestables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aspnetrolegroups",
                columns: table => new
                {
                    RoleGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetrolegroups", x => x.RoleGroupId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "aspnetrolegrouproles",
                columns: table => new
                {
                    RoleGroupRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleGroupId = table.Column<int>(type: "int", nullable: false),
                    ApplicationRoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetrolegrouproles", x => x.RoleGroupRoleId);
                    table.ForeignKey(
                        name: "FK_aspnetrolegrouproles_aspnetrolegroups_RoleGroupId",
                        column: x => x.RoleGroupId,
                        principalTable: "aspnetrolegroups",
                        principalColumn: "RoleGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_aspnetrolegrouproles_AspNetRoles_ApplicationRoleId",
                        column: x => x.ApplicationRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_aspnetrolegrouproles_ApplicationRoleId",
                table: "aspnetrolegrouproles",
                column: "ApplicationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_aspnetrolegrouproles_RoleGroupId",
                table: "aspnetrolegrouproles",
                column: "RoleGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aspnetrolegrouproles");

            migrationBuilder.DropTable(
                name: "aspnetrolegroups");
        }
    }
}
