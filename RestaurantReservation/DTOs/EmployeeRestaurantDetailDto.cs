namespace RestaurantReservation.DTOs;

public record EmployeeRestaurantDetailDto(
    int EmployeeId,
    string EmployeeFirstName,
    string EmployeeLastName,
    string EmployeePosition,
    string RestaurantName,
    string RestaurantAddress,
    string RestaurantPhoneNumber,
    string RestaurantOpeningHours)
{
}