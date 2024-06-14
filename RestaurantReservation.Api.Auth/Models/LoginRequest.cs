namespace RestaurantReservation.Api.Auth.Models;

public record LoginRequest(
    string Username,
    string Password);