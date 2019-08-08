using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Message.Entity.Migrations
{
    public partial class CodeFirstTest10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SloginLastIp",
                table: "UserInfo",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TloginLastTime",
                table: "UserInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SloginLastIp",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "TloginLastTime",
                table: "UserInfo");
        }
    }
}
