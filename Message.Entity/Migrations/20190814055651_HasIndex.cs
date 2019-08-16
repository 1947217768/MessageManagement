using Microsoft.EntityFrameworkCore.Migrations;

namespace Message.Entity.Migrations
{
    public partial class HasIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserRole_IroleId_IuserId",
                table: "UserRole",
                columns: new[] { "IroleId", "IuserId" });

            migrationBuilder.CreateIndex(
                name: "IX_UploadFileInfo_Uid",
                table: "UploadFileInfo",
                column: "Uid");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenu_IroleId_ImenuId",
                table: "RoleMenu",
                columns: new[] { "IroleId", "ImenuId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRole_IroleId_IuserId",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UploadFileInfo_Uid",
                table: "UploadFileInfo");

            migrationBuilder.DropIndex(
                name: "IX_RoleMenu_IroleId_ImenuId",
                table: "RoleMenu");
        }
    }
}
