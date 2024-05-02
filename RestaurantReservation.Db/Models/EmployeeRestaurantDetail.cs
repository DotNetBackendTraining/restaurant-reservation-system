namespace RestaurantReservation.Db.Models;

public class EmployeeRestaurantDetail
{
    public int EmployeeId { get; set; }
    public required string EmployeeFirstName { get; set; }
    public required string EmployeeLastName { get; set; }
    public required string EmployeePosition { get; set; }
    public required string RestaurantName { get; set; }
    public required string RestaurantAddress { get; set; }
    public required string RestaurantPhoneNumber { get; set; }
    public required string RestaurantOpeningHours { get; set; }
}