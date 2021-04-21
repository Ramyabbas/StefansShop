using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StefanShopWeb.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        Name = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        UserName = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
            //        Email = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(nullable: false),
            //        PasswordHash = table.Column<string>(nullable: true),
            //        SecurityStamp = table.Column<string>(nullable: true),
            //        ConcurrencyStamp = table.Column<string>(nullable: true),
            //        PhoneNumber = table.Column<string>(nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
            //        LockoutEnabled = table.Column<bool>(nullable: false),
            //        AccessFailedCount = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Categories",
            //    columns: table => new
            //    {
            //        CategoryID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CategoryName = table.Column<string>(maxLength: 15, nullable: false),
            //        Description = table.Column<string>(type: "ntext", nullable: true),
            //        Picture = table.Column<byte[]>(type: "image", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Categories", x => x.CategoryID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Customers",
            //    columns: table => new
            //    {
            //        CustomerID = table.Column<string>(maxLength: 5, nullable: false),
            //        CompanyName = table.Column<string>(maxLength: 40, nullable: false),
            //        ContactName = table.Column<string>(maxLength: 30, nullable: true),
            //        ContactTitle = table.Column<string>(maxLength: 30, nullable: true),
            //        Address = table.Column<string>(maxLength: 60, nullable: true),
            //        City = table.Column<string>(maxLength: 15, nullable: true),
            //        Region = table.Column<string>(maxLength: 15, nullable: true),
            //        PostalCode = table.Column<string>(maxLength: 10, nullable: true),
            //        Country = table.Column<string>(maxLength: 15, nullable: true),
            //        Phone = table.Column<string>(maxLength: 24, nullable: true),
            //        Fax = table.Column<string>(maxLength: 24, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Customers", x => x.CustomerID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Employees",
            //    columns: table => new
            //    {
            //        EmployeeID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LastName = table.Column<string>(maxLength: 20, nullable: false),
            //        FirstName = table.Column<string>(maxLength: 10, nullable: false),
            //        Title = table.Column<string>(maxLength: 30, nullable: true),
            //        TitleOfCourtesy = table.Column<string>(maxLength: 25, nullable: true),
            //        BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        HireDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        Address = table.Column<string>(maxLength: 60, nullable: true),
            //        City = table.Column<string>(maxLength: 15, nullable: true),
            //        Region = table.Column<string>(maxLength: 15, nullable: true),
            //        PostalCode = table.Column<string>(maxLength: 10, nullable: true),
            //        Country = table.Column<string>(maxLength: 15, nullable: true),
            //        HomePhone = table.Column<string>(maxLength: 24, nullable: true),
            //        Extension = table.Column<string>(maxLength: 4, nullable: true),
            //        Photo = table.Column<byte[]>(type: "image", nullable: true),
            //        Notes = table.Column<string>(type: "ntext", nullable: true),
            //        ReportsTo = table.Column<int>(nullable: true),
            //        PhotoPath = table.Column<string>(maxLength: 255, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Employees", x => x.EmployeeID);
            //        table.ForeignKey(
            //            name: "FK_Employees_Employees_ReportsTo",
            //            column: x => x.ReportsTo,
            //            principalTable: "Employees",
            //            principalColumn: "EmployeeID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            migrationBuilder.CreateTable(
                name: "NewsLetters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsLetters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsLetterSubscribers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsLetterSubscribers", x => x.Id);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "NewsLetters");

            migrationBuilder.DropTable(
                name: "NewsLetterSubscribers");

            migrationBuilder.DropTable(
                name: "Order Details");

            migrationBuilder.DropTable(
                name: "Territories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Shippers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
