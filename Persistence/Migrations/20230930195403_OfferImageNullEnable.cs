using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OfferImageNullEnable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19e3d4bf-37f2-4ed6-8ae3-8c6eae9920be"),
                column: "ConcurrencyStamp",
                value: "b6c2c717-279b-45fa-afd8-73b4115c6c7f");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19e3d4bf-37f2-4ed6-8ae3-8c6eae9920be"),
                column: "ConcurrencyStamp",
                value: "949045ca-af7d-4359-88f8-b9f8376c3a4a");
        }
    }
}
