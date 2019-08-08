using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Message.Entity.Migrations
{
    public partial class CodeFirstTest13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UploadFileInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Uid = table.Column<Guid>(nullable: false),
                    SoriginalFileName = table.Column<string>(maxLength: 100, nullable: false),
                    SfileName = table.Column<string>(maxLength: 100, nullable: false),
                    SfileType = table.Column<string>(maxLength: 30, nullable: false),
                    SfilePath = table.Column<string>(maxLength: 500, nullable: false),
                    SrelativePath = table.Column<string>(maxLength: 500, nullable: false),
                    Isize = table.Column<int>(nullable: false),
                    Sremarks = table.Column<string>(maxLength: 200, nullable: true),
                    Screater = table.Column<string>(maxLength: 50, nullable: true),
                    TcreateTime = table.Column<DateTime>(nullable: true),
                    Smodifier = table.Column<string>(maxLength: 50, nullable: true),
                    TmodifyTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadFileInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UploadFileInfo");
        }
    }
}
