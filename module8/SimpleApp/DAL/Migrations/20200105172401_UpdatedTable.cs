using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdatedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Awards_Users_UserID",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAward_Awards_AwardId",
                table: "UserAward");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAward_Users_UserId",
                table: "UserAward");

            migrationBuilder.DropIndex(
                name: "IX_Awards_UserID",
                table: "Awards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAward",
                table: "UserAward");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Awards");

            migrationBuilder.RenameTable(
                name: "UserAward",
                newName: "UserAwards");

            migrationBuilder.RenameIndex(
                name: "IX_UserAward_UserId",
                table: "UserAwards",
                newName: "IX_UserAwards_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAward_AwardId",
                table: "UserAwards",
                newName: "IX_UserAwards_AwardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAwards",
                table: "UserAwards",
                column: "UserAwardId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAwards_Awards_AwardId",
                table: "UserAwards",
                column: "AwardId",
                principalTable: "Awards",
                principalColumn: "AwardID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAwards_Users_UserId",
                table: "UserAwards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAwards_Awards_AwardId",
                table: "UserAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAwards_Users_UserId",
                table: "UserAwards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAwards",
                table: "UserAwards");

            migrationBuilder.RenameTable(
                name: "UserAwards",
                newName: "UserAward");

            migrationBuilder.RenameIndex(
                name: "IX_UserAwards_UserId",
                table: "UserAward",
                newName: "IX_UserAward_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAwards_AwardId",
                table: "UserAward",
                newName: "IX_UserAward_AwardId");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Awards",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAward",
                table: "UserAward",
                column: "UserAwardId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserAward_Awards_AwardId",
                table: "UserAward",
                column: "AwardId",
                principalTable: "Awards",
                principalColumn: "AwardID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAward_Users_UserId",
                table: "UserAward",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
