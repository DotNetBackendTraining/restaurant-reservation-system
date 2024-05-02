using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationDetailsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW ReservationDetailsView AS
                SELECT
                    r.ReservationId,
                    r.ReservationDate,
                    r.PartySize,
                    c.FirstName AS CustomerFirstName,
                    c.LastName AS CustomerLastName,
                    c.Email AS CustomerEmail,
                    c.PhoneNumber AS CustomerPhoneNumber,
                    rest.Name AS RestaurantName,
                    rest.Address AS RestaurantAddress,
                    rest.PhoneNumber AS RestaurantPhoneNumber,
                    rest.OpeningHours AS RestaurantOpeningHours
                FROM Reservations r
                JOIN Customers c ON r.CustomerId = c.CustomerId
                JOIN Tables t ON r.TableId = t.TableId
                JOIN Restaurants rest ON t.RestaurantId = rest.RestaurantId;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW ReservationDetailsView;");
        }
    }
}
