using Microsoft.EntityFrameworkCore.Migrations;

namespace Message.Entity.Migrations
{
    public partial class CodeFurstTest11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bdelete",
                table: "Menu");

            migrationBuilder.AddColumn<string>(
                name: "Sremarks",
                table: "RoleMenu",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sremarks",
                table: "RoleMenu");

            migrationBuilder.AddColumn<bool>(
                name: "Bdelete",
                table: "Menu",
                nullable: true);
        }
    }
}
