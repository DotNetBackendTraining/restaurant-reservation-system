namespace RestaurantReservation.App.DTOs;

public record EmployeeDto(
    int EmployeeId,
    int RestaurantId,
    string FirstName,
    string LastName,
    string Position)
{
}