using Microsoft.EntityFrameworkCore.Migrations;

namespace Message.Entity.Migrations
{
    public partial class UpdateSystemController2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bvalid",
                table: "SystemController");

            migrationBuilder.AddColumn<bool>(
                name: "Bvalid",
                table: "SystemAction",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bvalid",
                table: "SystemAction");

            migrationBuilder.AddColumn<bool>(
                name: "Bvalid",
                table: "SystemController",
                nullable: false,
                defaultValue: false);
        }
    }
}
