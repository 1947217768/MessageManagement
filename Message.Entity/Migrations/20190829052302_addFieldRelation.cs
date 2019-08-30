using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Message.Entity.Migrations
{
    public partial class addFieldRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FieldRelation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sremarks = table.Column<string>(maxLength: 200, nullable: true),
                    Screater = table.Column<string>(maxLength: 50, nullable: false),
                    TcreateTime = table.Column<DateTime>(nullable: true),
                    Smodifier = table.Column<string>(maxLength: 50, nullable: false),
                    TmodifyTime = table.Column<DateTime>(nullable: true),
                    IprimarykeyId = table.Column<int>(nullable: false),
                    IforeignkeyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldRelation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldRelation_IforeignkeyId_IprimarykeyId",
                table: "FieldRelation",
                columns: new[] { "IforeignkeyId", "IprimarykeyId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldRelation");
        }
    }
}
