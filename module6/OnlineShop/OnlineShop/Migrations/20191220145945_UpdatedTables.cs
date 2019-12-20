using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Migrations
{
    public partial class UpdatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Sellers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Sellers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Sellers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Sellers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Quantity",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WroteTime",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Cards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "Cards",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Cards",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Cards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "WroteTime",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Cards");
        }
    }
}
