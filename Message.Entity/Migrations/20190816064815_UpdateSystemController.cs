using Microsoft.EntityFrameworkCore.Migrations;

namespace Message.Entity.Migrations
{
    public partial class UpdateSystemController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SresultType",
                table: "SystemController");

            migrationBuilder.AddColumn<string>(
                name: "SresultType",
                table: "SystemAction",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SresultType",
                table: "SystemAction");

            migrationBuilder.AddColumn<string>(
                name: "SresultType",
                table: "SystemController",
                nullable: true);
        }
    }
}
