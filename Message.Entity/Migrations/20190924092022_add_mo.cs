using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Message.Entity.Migrations
{
    public partial class add_mo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataTables");

            migrationBuilder.DropTable(
                name: "Memorandum");

            migrationBuilder.CreateTable(
                name: "Memo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sremarks = table.Column<string>(maxLength: 200, nullable: true),
                    Screater = table.Column<string>(maxLength: 50, nullable: false),
                    TcreateTime = table.Column<DateTime>(nullable: true),
                    Smodifier = table.Column<string>(maxLength: 50, nullable: false),
                    TmodifyTime = table.Column<DateTime>(nullable: true),
                    Scontent = table.Column<string>(maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Memo");

            migrationBuilder.CreateTable(
                name: "DataTables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdataBaseId = table.Column<int>(nullable: false),
                    Screater = table.Column<string>(nullable: true),
                    Smodifier = table.Column<string>(nullable: true),
                    Sremarks = table.Column<string>(nullable: true),
                    StableName = table.Column<string>(nullable: true),
                    TcreateTime = table.Column<DateTime>(nullable: true),
                    TmodifyTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Memorandum",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Scontent = table.Column<string>(maxLength: 10000, nullable: true),
                    Screater = table.Column<string>(maxLength: 50, nullable: false),
                    Smodifier = table.Column<string>(maxLength: 50, nullable: false),
                    Sremarks = table.Column<string>(maxLength: 200, nullable: true),
                    TcreateTime = table.Column<DateTime>(nullable: true),
                    TmodifyTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memorandum", x => x.Id);
                });
        }
    }
}
