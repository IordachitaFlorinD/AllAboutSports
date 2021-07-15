using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllAboutSports.Data.Migrations
{
    public partial class UpdatedShippingAddressesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ShippingAddress",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "ShippingAddress",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ShippingAddress",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ShippingAddress");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ShippingAddress");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ShippingAddress");
        }
    }
}
