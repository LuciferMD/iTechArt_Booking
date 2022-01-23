using Microsoft.EntityFrameworkCore.Migrations;

namespace iTechArt_Booking.Infastructure.Migrations
{
    public partial class ver3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Hotels_Hotelid",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "Hotelid",
                table: "Reviews",
                newName: "HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_Hotelid",
                table: "Reviews",
                newName: "IX_Reviews_HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Hotels_HotelId",
                table: "Reviews",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Hotels_HotelId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "Reviews",
                newName: "Hotelid");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_HotelId",
                table: "Reviews",
                newName: "IX_Reviews_Hotelid");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Hotels_Hotelid",
                table: "Reviews",
                column: "Hotelid",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
