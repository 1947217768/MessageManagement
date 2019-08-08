using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Message.Entity.Migrations
{
    public partial class CodeFirstTest1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataBase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SdataBaseName = table.Column<string>(maxLength: 200, nullable: false),
                    Sremarks = table.Column<string>(maxLength: 200, nullable: true),
                    Screater = table.Column<string>(maxLength: 50, nullable: false),
                    TcreateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Smodifier = table.Column<string>(maxLength: 50, nullable: false),
                    TmodifyTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataTables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdataBaseId = table.Column<int>(nullable: false),
                    StableName = table.Column<string>(maxLength: 200, nullable: false),
                    Sremarks = table.Column<string>(maxLength: 200, nullable: true),
                    Screater = table.Column<string>(maxLength: 50, nullable: false),
                    TcreateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Smodifier = table.Column<string>(maxLength: 50, nullable: false),
                    TmodifyTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IparentId = table.Column<int>(nullable: false),
                    Sname = table.Column<string>(maxLength: 128, nullable: false),
                    SiconUrl = table.Column<string>(maxLength: 128, nullable: true),
                    SlinkUrl = table.Column<string>(maxLength: 128, nullable: true),
                    Isort = table.Column<int>(nullable: false),
                    Bdisplay = table.Column<bool>(nullable: true),
                    Bdelete = table.Column<bool>(nullable: true),
                    Sremarks = table.Column<string>(maxLength: 200, nullable: true),
                    Screater = table.Column<string>(maxLength: 50, nullable: false),
                    TcreateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Smodifier = table.Column<string>(maxLength: 50, nullable: false),
                    TmodifyTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENU", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "RoleMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IroleId = table.Column<int>(nullable: false),
                    ImenuId = table.Column<int>(nullable: false),
                    Screater = table.Column<string>(maxLength: 50, nullable: false),
                    TcreateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Smodifier = table.Column<string>(maxLength: 50, nullable: false),
                    TmodifyTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SloginName = table.Column<string>(maxLength: 30, nullable: false),
                    SloginPwd = table.Column<string>(maxLength: 100, nullable: false),
                    SuserName = table.Column<string>(maxLength: 20, nullable: false),
                    SuserPhone = table.Column<string>(maxLength: 50, nullable: false),
                    SuserEmail = table.Column<string>(maxLength: 50, nullable: false),
                    Sremarks = table.Column<string>(maxLength: 200, nullable: false),
                    Screater = table.Column<string>(nullable: true),
                    TcreateTime = table.Column<DateTime>(nullable: true),
                    Smodifier = table.Column<string>(nullable: true),
                    TmodifyTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataBase");

            migrationBuilder.DropTable(
                name: "DataTables");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "RoleMenu");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
