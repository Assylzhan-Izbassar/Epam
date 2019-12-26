using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Migrations
{
    public partial class UpdatedCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CostomerID",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CustomerID",
                table: "Comments",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductID",
                table: "Comments",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Customers_CustomerID",
                table: "Comments",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Products_ProductID",
                table: "Comments",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Customers_CustomerID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Products_ProductID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CustomerID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ProductID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CostomerID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
