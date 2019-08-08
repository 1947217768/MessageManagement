using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Message.Entity.Migrations
{
    public partial class CodeFirstTest6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SroleName = table.Column<string>(maxLength: 50, nullable: false),
                    Sremarks = table.Column<string>(maxLength: 200, nullable: true),
                    Screater = table.Column<string>(maxLength: 50, nullable: true),
                    TcreateTime = table.Column<DateTime>(nullable: true),
                    Smodifier = table.Column<string>(maxLength: 50, nullable: true),
                    TmodifyTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IuserId = table.Column<int>(nullable: false),
                    IroleId = table.Column<int>(nullable: false),
                    Sremarks = table.Column<string>(maxLength: 200, nullable: true),
                    Screater = table.Column<string>(maxLength: 50, nullable: true),
                    TcreateTime = table.Column<DateTime>(nullable: true),
                    Smodifier = table.Column<string>(maxLength: 50, nullable: true),
                    TmodifyTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
