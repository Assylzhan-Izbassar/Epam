using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Upd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Awards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Awards_UserID",
                table: "Awards",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_Users_UserID",
                table: "Awards",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Awards_Users_UserID",
                table: "Awards");

            migrationBuilder.DropIndex(
                name: "IX_Awards_UserID",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Awards");
        }
    }
}
