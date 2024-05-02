using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeRestaurantDetailsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW EmployeeRestaurantDetailsView AS
                SELECT 
                    e.EmployeeId,
                    e.FirstName AS EmployeeFirstName,
                    e.LastName AS EmployeeLastName,
                    e.Position AS EmployeePosition,
                    r.Name AS RestaurantName,
                    r.Address AS RestaurantAddress,
                    r.PhoneNumber AS RestaurantPhoneNumber,
                    r.OpeningHours AS RestaurantOpeningHours
                FROM Employees e
                JOIN Restaurants r ON e.RestaurantId = r.RestaurantId;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW EmployeeRestaurantDetailsView;");
        }
    }
}
