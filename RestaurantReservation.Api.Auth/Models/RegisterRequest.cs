namespace RestaurantReservation.Api.Auth.Models;

public record RegisterRequest(
    string Username,
    string Password);