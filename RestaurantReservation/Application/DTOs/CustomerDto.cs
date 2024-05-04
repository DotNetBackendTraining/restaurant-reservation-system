namespace RestaurantReservation.Application.DTOs;

public record CustomerDto(
    int CustomerId,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber)
{
}