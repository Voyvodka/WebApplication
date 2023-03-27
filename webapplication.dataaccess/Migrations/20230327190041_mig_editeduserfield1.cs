using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapplication.dataaccess.Migrations
{
    public partial class mig_editeduserfield1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "AspNetUsers",
                newName: "LastName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "Surname");
        }
    }
}
