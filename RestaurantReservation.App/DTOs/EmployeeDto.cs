namespace RestaurantReservation.App.DTOs;

public record EmployeeDto(
    int EmployeeId,
    string FirstName,
    string LastName,
    string Position)
{
}