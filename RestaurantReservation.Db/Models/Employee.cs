namespace RestaurantReservation.Db.Models;

public class Employee
{
    public int EmployeeId { get; set; }

    public required int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Position { get; set; }
}