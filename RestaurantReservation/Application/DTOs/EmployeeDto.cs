namespace RestaurantReservation.Application.DTOs;

public record EmployeeDto(
    int EmployeeId,
    string FirstName,
    string LastName,
    string Position)
{
}