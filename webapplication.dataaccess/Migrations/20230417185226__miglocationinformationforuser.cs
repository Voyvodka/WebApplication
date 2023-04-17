using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable
namespace webapplication.dataaccess.Migrations
{
    public partial class _miglocationinformationforuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropColumn(
            //     name: "Country",
            //     table: "AspNetUsers");
            // migrationBuilder.AddColumn<int>(
            //     name: "CityId",
            //     table: "AspNetUsers",
            //     type: "int",
            //     nullable: true);
            // migrationBuilder.AddColumn<int>(
            //     name: "CountryId",
            //     table: "AspNetUsers",
            //     type: "int",
            //     nullable: true);
            // migrationBuilder.AddColumn<int>(
            //     name: "StateId",
            //     table: "AspNetUsers",
            //     type: "int",
            //     nullable: true);
            // migrationBuilder.CreateIndex(
            //     name: "IX_AspNetUsers_CityId",
            //     table: "AspNetUsers",
            //     column: "CityId");
            // migrationBuilder.CreateIndex(
            //     name: "IX_AspNetUsers_CountryId",
            //     table: "AspNetUsers",
            //     column: "CountryId");
            // migrationBuilder.CreateIndex(
            //     name: "IX_AspNetUsers_StateId",
            //     table: "AspNetUsers",
            //     column: "StateId");
            // migrationBuilder.AddForeignKey(
            //     name: "FK_AspNetUsers_City_CityId",
            //     table: "AspNetUsers",
            //     column: "CityId",
            //     principalTable: "cities",
            //     principalColumn: "id");
            // migrationBuilder.AddForeignKey(
            //     name: "FK_AspNetUsers_Country_CountryId",
            //     table: "AspNetUsers",
            //     column: "CountryId",
            //     principalTable: "countries",
            //     principalColumn: "id");
            // migrationBuilder.AddForeignKey(
            //     name: "FK_AspNetUsers_State_StateId",
            //     table: "AspNetUsers",
            //     column: "StateId",
            //     principalTable: "states",
            //     principalColumn: "id");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_AspNetUsers_City_CityId",
            //     table: "AspNetUsers");
            // migrationBuilder.DropForeignKey(
            //     name: "FK_AspNetUsers_Country_CountryId",
            //     table: "AspNetUsers");
            // migrationBuilder.DropForeignKey(
            //     name: "FK_AspNetUsers_State_StateId",
            //     table: "AspNetUsers");
            // migrationBuilder.DropIndex(
            //     name: "IX_AspNetUsers_CityId",
            //     table: "AspNetUsers");
            // migrationBuilder.DropIndex(
            //     name: "IX_AspNetUsers_CountryId",
            //     table: "AspNetUsers");
            // migrationBuilder.DropIndex(
            //     name: "IX_AspNetUsers_StateId",
            //     table: "AspNetUsers");
            // migrationBuilder.DropColumn(
            //     name: "CityId",
            //     table: "AspNetUsers");
            // migrationBuilder.DropColumn(
            //     name: "CountryId",
            //     table: "AspNetUsers");
            // migrationBuilder.DropColumn(
            //     name: "StateId",
            //     table: "AspNetUsers");
            // migrationBuilder.AddColumn<string>(
            //     name: "Country",
            //     table: "AspNetUsers",
            //     type: "longtext",
            //     nullable: true)
            //     .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
