using Microsoft.EntityFrameworkCore.Migrations;

namespace Message.Entity.Migrations
{
    public partial class updateMenuAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BisValid",
                table: "MenuAction",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sexplain",
                table: "MenuAction",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BisValid",
                table: "MenuAction");

            migrationBuilder.DropColumn(
                name: "Sexplain",
                table: "MenuAction");
        }
    }
}
