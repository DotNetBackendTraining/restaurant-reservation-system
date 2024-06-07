namespace RestaurantReservation.DTOs;

public record EmployeeDto(
    int EmployeeId,
    string FirstName,
    string LastName,
    string Position)
{
}