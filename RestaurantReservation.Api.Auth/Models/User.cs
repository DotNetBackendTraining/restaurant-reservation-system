using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Api.Auth.Models;

public class User
{
    [Key] public Guid Id { get; set; }
    [StringLength(256)] public string Username { get; set; } = string.Empty;
    [StringLength(256)] public string PasswordHash { get; set; } = string.Empty;
    [StringLength(100)] public string Role { get; set; } = "user";
}