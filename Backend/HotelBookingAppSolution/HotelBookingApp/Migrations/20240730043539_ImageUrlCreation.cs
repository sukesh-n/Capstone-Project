using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingApp.Migrations
{
    public partial class ImageUrlCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelImages",
                table: "HotelImages");

            migrationBuilder.DropColumn(
                name: "RoomImage",
                table: "HotelImages");

            migrationBuilder.AddColumn<int>(
                name: "HotelImageId",
                table: "HotelImages",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "RoomImageUrl",
                table: "HotelImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelImages",
                table: "HotelImages",
                column: "HotelImageId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelImages_HotelBranchId",
                table: "HotelImages",
                column: "HotelBranchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelImages",
                table: "HotelImages");

            migrationBuilder.DropIndex(
                name: "IX_HotelImages_HotelBranchId",
                table: "HotelImages");

            migrationBuilder.DropColumn(
                name: "HotelImageId",
                table: "HotelImages");

            migrationBuilder.DropColumn(
                name: "RoomImageUrl",
                table: "HotelImages");

            migrationBuilder.AddColumn<byte[]>(
                name: "RoomImage",
                table: "HotelImages",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelImages",
                table: "HotelImages",
                column: "HotelBranchId");
        }
    }
}
