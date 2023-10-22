using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UDB003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PayNowReferrence",
                table: "ParkingTicketPayments",
                newName: "PaymentReferrence");

            migrationBuilder.RenameColumn(
                name: "PayNowHash",
                table: "ParkingTicketPayments",
                newName: "PaymentPlatform");

            migrationBuilder.RenameColumn(
                name: "MobileMoney",
                table: "ParkingTicketPayments",
                newName: "PaymentHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentReferrence",
                table: "ParkingTicketPayments",
                newName: "PayNowReferrence");

            migrationBuilder.RenameColumn(
                name: "PaymentPlatform",
                table: "ParkingTicketPayments",
                newName: "PayNowHash");

            migrationBuilder.RenameColumn(
                name: "PaymentHash",
                table: "ParkingTicketPayments",
                newName: "MobileMoney");
        }
    }
}
