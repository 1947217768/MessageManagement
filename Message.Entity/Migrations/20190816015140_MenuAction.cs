using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Message.Entity.Migrations
{
    public partial class MenuAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuAction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sremarks = table.Column<string>(maxLength: 200, nullable: true),
                    Screater = table.Column<string>(maxLength: 50, nullable: false),
                    TcreateTime = table.Column<DateTime>(nullable: true),
                    Smodifier = table.Column<string>(maxLength: 50, nullable: false),
                    TmodifyTime = table.Column<DateTime>(nullable: true),
                    ImenuId = table.Column<int>(nullable: false),
                    IactionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuAction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemAction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sremarks = table.Column<string>(maxLength: 200, nullable: true),
                    Screater = table.Column<string>(maxLength: 50, nullable: false),
                    TcreateTime = table.Column<DateTime>(nullable: true),
                    Smodifier = table.Column<string>(maxLength: 50, nullable: false),
                    TmodifyTime = table.Column<DateTime>(nullable: true),
                    SactionName = table.Column<string>(maxLength: 200, nullable: true),
                    IcontrollerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemAction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemController",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sremarks = table.Column<string>(maxLength: 200, nullable: true),
                    Screater = table.Column<string>(maxLength: 50, nullable: false),
                    TcreateTime = table.Column<DateTime>(nullable: true),
                    Smodifier = table.Column<string>(maxLength: 50, nullable: false),
                    TmodifyTime = table.Column<DateTime>(nullable: true),
                    ScontrollerName = table.Column<string>(maxLength: 100, nullable: true),
                    SresultType = table.Column<string>(nullable: true),
                    Bvalid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemController", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuAction_ImenuId_IactionId",
                table: "MenuAction",
                columns: new[] { "ImenuId", "IactionId" });

            migrationBuilder.CreateIndex(
                name: "IX_SystemAction_IcontrollerId",
                table: "SystemAction",
                column: "IcontrollerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuAction");

            migrationBuilder.DropTable(
                name: "SystemAction");

            migrationBuilder.DropTable(
                name: "SystemController");
        }
    }
}
