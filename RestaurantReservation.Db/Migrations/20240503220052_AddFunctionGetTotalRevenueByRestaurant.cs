using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddFunctionGetTotalRevenueByRestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE FUNCTION GetTotalRevenueByRestaurant (@RestaurantId INT)
                RETURNS DECIMAL(18,2)
                AS
                BEGIN
                    RETURN (
                        SELECT SUM(o.TotalAmount) 
                        FROM Restaurants r
                        JOIN Tables t ON r.RestaurantId = t.RestaurantId
                        JOIN Reservations res ON t.TableId = res.TableId
                        JOIN Orders o ON res.ReservationId = o.ReservationId
                        WHERE r.RestaurantId = @RestaurantId
                    )
                END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION GetTotalRevenueByRestaurant;");
        }
    }
}
