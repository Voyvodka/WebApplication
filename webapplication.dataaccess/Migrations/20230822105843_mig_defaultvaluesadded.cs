using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapplication.dataaccess.Migrations
{
    public partial class mig_defaultvaluesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "states",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "states",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "states",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPassive",
                table: "states",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "states",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Modules",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Modules",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Modules",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPassive",
                table: "Modules",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Modules",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ModuleMenus",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "ModuleMenus",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ModuleMenus",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPassive",
                table: "ModuleMenus",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ModuleMenus",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Menus",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Menus",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Menus",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPassive",
                table: "Menus",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Menus",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "MenuHeaders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "MenuHeaders",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MenuHeaders",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPassive",
                table: "MenuHeaders",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "MenuHeaders",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "countries",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "countries",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "countries",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPassive",
                table: "countries",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "countries",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "cities",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "cities",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "cities",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPassive",
                table: "cities",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "cities",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "aspnetrolegroups",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "aspnetrolegroups",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "aspnetrolegroups",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPassive",
                table: "aspnetrolegroups",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "aspnetrolegroups",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "aspnetrolegrouproles",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "aspnetrolegrouproles",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "aspnetrolegrouproles",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPassive",
                table: "aspnetrolegrouproles",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "aspnetrolegrouproles",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AdminModules",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "AdminModules",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AdminModules",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPassive",
                table: "AdminModules",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "AdminModules",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AdminModuleMenus",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "AdminModuleMenus",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AdminModuleMenus",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPassive",
                table: "AdminModuleMenus",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "AdminModuleMenus",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AdminMenus",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "AdminMenus",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AdminMenus",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPassive",
                table: "AdminMenus",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "AdminMenus",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AdminMenuHeaders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "AdminMenuHeaders",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AdminMenuHeaders",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPassive",
                table: "AdminMenuHeaders",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "AdminMenuHeaders",
                type: "datetime(6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "states");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "states");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "states");

            migrationBuilder.DropColumn(
                name: "IsPassive",
                table: "states");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "states");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "IsPassive",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ModuleMenus");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ModuleMenus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ModuleMenus");

            migrationBuilder.DropColumn(
                name: "IsPassive",
                table: "ModuleMenus");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ModuleMenus");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "IsPassive",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "MenuHeaders");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "MenuHeaders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MenuHeaders");

            migrationBuilder.DropColumn(
                name: "IsPassive",
                table: "MenuHeaders");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "MenuHeaders");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "countries");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "countries");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "countries");

            migrationBuilder.DropColumn(
                name: "IsPassive",
                table: "countries");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "countries");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "IsPassive",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "aspnetrolegroups");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "aspnetrolegroups");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "aspnetrolegroups");

            migrationBuilder.DropColumn(
                name: "IsPassive",
                table: "aspnetrolegroups");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "aspnetrolegroups");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "aspnetrolegrouproles");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "aspnetrolegrouproles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "aspnetrolegrouproles");

            migrationBuilder.DropColumn(
                name: "IsPassive",
                table: "aspnetrolegrouproles");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "aspnetrolegrouproles");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AdminModules");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "AdminModules");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AdminModules");

            migrationBuilder.DropColumn(
                name: "IsPassive",
                table: "AdminModules");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "AdminModules");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AdminModuleMenus");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "AdminModuleMenus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AdminModuleMenus");

            migrationBuilder.DropColumn(
                name: "IsPassive",
                table: "AdminModuleMenus");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "AdminModuleMenus");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AdminMenus");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "AdminMenus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AdminMenus");

            migrationBuilder.DropColumn(
                name: "IsPassive",
                table: "AdminMenus");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "AdminMenus");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AdminMenuHeaders");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "AdminMenuHeaders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AdminMenuHeaders");

            migrationBuilder.DropColumn(
                name: "IsPassive",
                table: "AdminMenuHeaders");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "AdminMenuHeaders");
        }
    }
}
