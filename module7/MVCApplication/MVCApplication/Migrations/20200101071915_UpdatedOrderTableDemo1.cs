using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCApplication.Migrations
{
    public partial class UpdatedOrderTableDemo1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ShipedDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShipedDate",
                table: "Orders");
        }
    }
}
