﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapplication.dataaccess.Contexts;

#nullable disable

namespace webapplication.dataaccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("webapplication.entity.AdminMenu", b =>
                {
                    b.Property<int>("AdminMenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AdminMenuHeaderId")
                        .HasColumnType("int");

                    b.Property<string>("AdminMenuHref")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AdminMenuIconPath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AdminMenuKeyword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AdminMenuText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ApplicationRoleId")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Passive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("AdminMenuId");

                    b.HasIndex("AdminMenuHeaderId");

                    b.HasIndex("ApplicationRoleId");

                    b.ToTable("AdminMenus");
                });

            modelBuilder.Entity("webapplication.entity.AdminMenuHeader", b =>
                {
                    b.Property<int>("AdminMenuHeaderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AdminMenuHeaderIconPath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AdminMenuHeaderText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Passive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("AdminMenuHeaderId");

                    b.ToTable("AdminMenuHeaders");
                });

            modelBuilder.Entity("webapplication.entity.AdminModule", b =>
                {
                    b.Property<int>("AdminModuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AdminModuleIconPath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AdminModuleText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Passive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("AdminModuleId");

                    b.ToTable("AdminModules");
                });

            modelBuilder.Entity("webapplication.entity.AdminModuleMenu", b =>
                {
                    b.Property<int>("AdminModuleMenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AdminMenuId")
                        .HasColumnType("int");

                    b.Property<int>("AdminModuleId")
                        .HasColumnType("int");

                    b.HasKey("AdminModuleMenuId");

                    b.HasIndex("AdminMenuId");

                    b.HasIndex("AdminModuleId");

                    b.ToTable("AdminModuleMenus");
                });

            modelBuilder.Entity("webapplication.entity.City", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("Countryid")
                        .HasColumnType("int");

                    b.Property<int?>("Stateid")
                        .HasColumnType("int");

                    b.Property<string>("country_code")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<int>("country_id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("state_code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("state_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Countryid");

                    b.HasIndex("Stateid");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("webapplication.entity.Country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("capital")
                        .HasColumnType("longtext");

                    b.Property<string>("currency")
                        .HasColumnType("longtext");

                    b.Property<string>("currency_symbol")
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("phonecode")
                        .HasColumnType("longtext");

                    b.Property<string>("region")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("countries");
                });

            modelBuilder.Entity("webapplication.entity.Identity.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("webapplication.entity.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("ImagePath")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<int?>("StateId")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Website")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("StateId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("webapplication.entity.Identity.RoleGroup", b =>
                {
                    b.Property<int>("RoleGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RoleGroupId");

                    b.ToTable("aspnetrolegroups");
                });

            modelBuilder.Entity("webapplication.entity.Identity.RoleGroupRole", b =>
                {
                    b.Property<int>("RoleGroupRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ApplicationRoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("RoleGroupId")
                        .HasColumnType("int");

                    b.HasKey("RoleGroupRoleId");

                    b.HasIndex("ApplicationRoleId");

                    b.HasIndex("RoleGroupId");

                    b.ToTable("aspnetrolegrouproles");
                });

            modelBuilder.Entity("webapplication.entity.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ApplicationRoleId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("MenuHeaderId")
                        .HasColumnType("int");

                    b.Property<string>("MenuHref")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MenuIconPath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MenuKeyword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MenuText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Passive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("MenuId");

                    b.HasIndex("ApplicationRoleId");

                    b.HasIndex("MenuHeaderId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("webapplication.entity.MenuHeader", b =>
                {
                    b.Property<int>("MenuHeaderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("MenuHeaderIconPath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MenuHeaderText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Passive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("MenuHeaderId");

                    b.ToTable("MenuHeaders");
                });

            modelBuilder.Entity("webapplication.entity.Module", b =>
                {
                    b.Property<int>("ModuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ModuleIconPath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ModuleText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Passive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("ModuleId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("webapplication.entity.ModuleMenu", b =>
                {
                    b.Property<int>("ModuleMenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.HasKey("ModuleMenuId");

                    b.HasIndex("MenuId");

                    b.HasIndex("ModuleId");

                    b.ToTable("ModuleMenus");
                });

            modelBuilder.Entity("webapplication.entity.State", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("Countryid")
                        .HasColumnType("int");

                    b.Property<string>("country_code")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<int>("country_id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("Countryid");

                    b.ToTable("states");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("webapplication.entity.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("webapplication.entity.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("webapplication.entity.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("webapplication.entity.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapplication.entity.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("webapplication.entity.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("webapplication.entity.AdminMenu", b =>
                {
                    b.HasOne("webapplication.entity.AdminMenuHeader", "AdminMenuHeader")
                        .WithMany()
                        .HasForeignKey("AdminMenuHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapplication.entity.Identity.ApplicationRole", "ApplicationRole")
                        .WithMany()
                        .HasForeignKey("ApplicationRoleId");

                    b.Navigation("AdminMenuHeader");

                    b.Navigation("ApplicationRole");
                });

            modelBuilder.Entity("webapplication.entity.AdminModuleMenu", b =>
                {
                    b.HasOne("webapplication.entity.AdminMenu", "AdminMenu")
                        .WithMany()
                        .HasForeignKey("AdminMenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapplication.entity.AdminModule", "AdminModule")
                        .WithMany()
                        .HasForeignKey("AdminModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdminMenu");

                    b.Navigation("AdminModule");
                });

            modelBuilder.Entity("webapplication.entity.City", b =>
                {
                    b.HasOne("webapplication.entity.Country", "Country")
                        .WithMany()
                        .HasForeignKey("Countryid");

                    b.HasOne("webapplication.entity.State", "State")
                        .WithMany()
                        .HasForeignKey("Stateid");

                    b.Navigation("Country");

                    b.Navigation("State");
                });

            modelBuilder.Entity("webapplication.entity.Identity.ApplicationUser", b =>
                {
                    b.HasOne("webapplication.entity.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("webapplication.entity.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("webapplication.entity.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("State");
                });

            modelBuilder.Entity("webapplication.entity.Identity.RoleGroupRole", b =>
                {
                    b.HasOne("webapplication.entity.Identity.ApplicationRole", "ApplicationRole")
                        .WithMany()
                        .HasForeignKey("ApplicationRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapplication.entity.Identity.RoleGroup", "RoleGroup")
                        .WithMany()
                        .HasForeignKey("RoleGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationRole");

                    b.Navigation("RoleGroup");
                });

            modelBuilder.Entity("webapplication.entity.Menu", b =>
                {
                    b.HasOne("webapplication.entity.Identity.ApplicationRole", "ApplicationRole")
                        .WithMany()
                        .HasForeignKey("ApplicationRoleId");

                    b.HasOne("webapplication.entity.MenuHeader", "MenuHeader")
                        .WithMany()
                        .HasForeignKey("MenuHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationRole");

                    b.Navigation("MenuHeader");
                });

            modelBuilder.Entity("webapplication.entity.ModuleMenu", b =>
                {
                    b.HasOne("webapplication.entity.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapplication.entity.Module", "Module")
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Module");
                });

            modelBuilder.Entity("webapplication.entity.State", b =>
                {
                    b.HasOne("webapplication.entity.Country", "Country")
                        .WithMany()
                        .HasForeignKey("Countryid");

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}
