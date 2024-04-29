using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "johndoe@example.com", "John", "Doe", "123-456-7890" },
                    { 2, "janesmith@example.com", "Jane", "Smith", "234-567-8901" },
                    { 3, "bobjohnson@example.com", "Bob", "Johnson", "345-678-9012" },
                    { 4, "alicewilliams@example.com", "Alice", "Williams", "456-789-0123" },
                    { 5, "stevebrown@example.com", "Steve", "Brown", "567-890-1234" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "Address", "Name", "OpeningHours", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St", "Good Eats", "9:00 AM - 9:00 PM", "987-654-3210" },
                    { 2, "456 Side St", "The Food Place", "10:00 AM - 10:00 PM", "876-543-2109" },
                    { 3, "789 Off Rd", "Dine Fine", "8:00 AM - 8:00 PM", "765-432-1098" },
                    { 4, "321 Fourth St", "The Quiet Bite", "7:00 AM - 7:00 PM", "654-321-0987" },
                    { 5, "654 Fifth Ave", "Spice Town", "11:00 AM - 11:00 PM", "543-210-9876" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "Position", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Alice", "Brown", "Manager", 1 },
                    { 2, "Carlos", "Davis", "Chef", 1 },
                    { 3, "Eva", "Green", "Waitress", 2 },
                    { 4, "David", "Miller", "Bartender", 2 },
                    { 5, "Olivia", "Wilson", "Hostess", 3 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "ItemId", "Description", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Large pizza with extra cheese", "Cheese Pizza", 15.99m, 1 },
                    { 2, "Burger with gourmet veggies", "Veggie Burger", 12.5m, 1 },
                    { 3, "Ribeye steak with garlic butter", "Steak", 25.75m, 2 },
                    { 4, "Pasta with creamy sauce and pancetta", "Spaghetti Carbonara", 14.5m, 2 },
                    { 5, "Crisp romaine lettuce with Caesar dressing", "Caesar Salad", 10m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Capacity", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 2, 1 },
                    { 3, 6, 2 },
                    { 4, 4, 2 },
                    { 5, 8, 3 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CustomerId", "PartySize", "ReservationDate", "TableId" },
                values: new object[,]
                {
                    { 1, 1, 4, new DateTime(2024, 4, 29, 19, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 2, 2, 2, new DateTime(2024, 4, 29, 20, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 3, 3, 6, new DateTime(2024, 4, 29, 21, 0, 0, 0, DateTimeKind.Local), 3 },
                    { 4, 4, 3, new DateTime(2024, 4, 29, 18, 0, 0, 0, DateTimeKind.Local), 4 },
                    { 5, 5, 5, new DateTime(2024, 4, 29, 22, 0, 0, 0, DateTimeKind.Local), 5 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "EmployeeId", "OrderDate", "ReservationId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 4, 29, 18, 19, 7, 497, DateTimeKind.Local).AddTicks(9073), 1, 45.9m },
                    { 2, 2, new DateTime(2024, 4, 29, 18, 19, 7, 497, DateTimeKind.Local).AddTicks(9117), 2, 22.3m },
                    { 3, 3, new DateTime(2024, 4, 29, 18, 19, 7, 497, DateTimeKind.Local).AddTicks(9120), 3, 98.6m },
                    { 4, 4, new DateTime(2024, 4, 29, 18, 19, 7, 497, DateTimeKind.Local).AddTicks(9122), 4, 33.5m },
                    { 5, 5, new DateTime(2024, 4, 29, 18, 19, 7, 497, DateTimeKind.Local).AddTicks(9124), 5, 57.75m }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "MenuItemId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 2, 2, 1 },
                    { 3, 3, 3, 4 },
                    { 4, 4, 4, 3 },
                    { 5, 5, 5, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 3);
        }
    }
}
