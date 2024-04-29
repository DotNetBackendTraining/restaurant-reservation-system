using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddCheckConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Tables_Capacity",
                table: "Tables",
                sql: "Capacity >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Reservations_PartySize",
                table: "Reservations",
                sql: "PartySize > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Orders_TotalAmount",
                table: "Orders",
                sql: "TotalAmount >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_OrderItems_Quantity",
                table: "OrderItems",
                sql: "Quantity >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_MenuItems_Price",
                table: "MenuItems",
                sql: "Price >= 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Tables_Capacity",
                table: "Tables");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Reservations_PartySize",
                table: "Reservations");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Orders_TotalAmount",
                table: "Orders");

            migrationBuilder.DropCheckConstraint(
                name: "CK_OrderItems_Quantity",
                table: "OrderItems");

            migrationBuilder.DropCheckConstraint(
                name: "CK_MenuItems_Price",
                table: "MenuItems");
        }
    }
}
