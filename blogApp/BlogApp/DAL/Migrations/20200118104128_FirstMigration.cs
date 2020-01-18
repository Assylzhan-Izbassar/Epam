using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryId1",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CategoryId1",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId1",
                table: "Posts",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryId1",
                table: "Posts",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
