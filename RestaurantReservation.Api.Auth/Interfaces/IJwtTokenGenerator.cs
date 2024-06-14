using RestaurantReservation.Api.Auth.Models;

namespace RestaurantReservation.Api.Auth.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}