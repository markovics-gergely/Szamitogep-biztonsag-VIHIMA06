using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webshop.DAL.Migrations
{
    public partial class CaffPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhysicalPath",
                table: "Caffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhysicalPath",
                table: "Caffs");
        }
    }
}
