using Microsoft.EntityFrameworkCore.Migrations;

namespace StefanShopWeb.Migrations
{
    public partial class NewsLetterIsSent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSent",
                table: "NewsLetters",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSent",
                table: "NewsLetters");
        }
    }
}
