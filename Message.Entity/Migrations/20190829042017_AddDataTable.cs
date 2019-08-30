using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Message.Entity.Migrations
{
    public partial class AddDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DataTables",
                table: "DataTables");

            migrationBuilder.RenameTable(
                name: "DataTables",
                newName: "DataTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataTable",
                table: "DataTable",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DataType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sremarks = table.Column<string>(maxLength: 200, nullable: true),
                    Screater = table.Column<string>(maxLength: 50, nullable: false),
                    TcreateTime = table.Column<DateTime>(nullable: true),
                    Smodifier = table.Column<string>(maxLength: 50, nullable: false),
                    TmodifyTime = table.Column<DateTime>(nullable: true),
                    StypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableFiled",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sremarks = table.Column<string>(maxLength: 200, nullable: true),
                    Screater = table.Column<string>(maxLength: 50, nullable: false),
                    TcreateTime = table.Column<DateTime>(nullable: true),
                    Smodifier = table.Column<string>(maxLength: 50, nullable: false),
                    TmodifyTime = table.Column<DateTime>(nullable: true),
                    SfiledName = table.Column<string>(nullable: true),
                    IdataTableId = table.Column<int>(nullable: false),
                    IdataTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableFiled", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataTable_IdataBaseId",
                table: "DataTable",
                column: "IdataBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TableFiled_IdataTableId_IdataTypeId",
                table: "TableFiled",
                columns: new[] { "IdataTableId", "IdataTypeId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataType");

            migrationBuilder.DropTable(
                name: "TableFiled");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DataTable",
                table: "DataTable");

            migrationBuilder.DropIndex(
                name: "IX_DataTable_IdataBaseId",
                table: "DataTable");

            migrationBuilder.RenameTable(
                name: "DataTable",
                newName: "DataTables");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataTables",
                table: "DataTables",
                column: "Id");
        }
    }
}
