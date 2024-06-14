using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using RestaurantReservation.Api.Auth.Db;
using RestaurantReservation.Api.Auth.Interfaces;
using RestaurantReservation.Api.Auth.Models;

namespace RestaurantReservation.Api.Auth.Services;

public class UserSeeder : IUserSeeder
{
    private readonly UserDbContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly AdminSettings _adminSettings;

    public UserSeeder(
        UserDbContext context,
        IPasswordHasher<User> passwordHasher,
        IOptions<AdminSettings> settings)
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _adminSettings = settings.Value;
    }

    public void SeedAdmins()
    {
        if (_context.Users
            .Any(user => user.Username == _adminSettings.Username))
        {
            return;
        }

        var adminUser = new User
        {
            Username = _adminSettings.Username,
            Role = "admin"
        };

        adminUser.PasswordHash = _passwordHasher.HashPassword(adminUser, _adminSettings.Password);

        _context.Users.Add(adminUser);
        _context.SaveChanges();
    }
}