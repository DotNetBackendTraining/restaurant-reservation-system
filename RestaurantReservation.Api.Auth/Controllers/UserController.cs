using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Api.Auth.Db;
using RestaurantReservation.Api.Auth.Interfaces;
using RestaurantReservation.Api.Auth.Models;
using LoginRequest = RestaurantReservation.Api.Auth.Models.LoginRequest;

namespace RestaurantReservation.Api.Auth.Controllers;

[ApiController]
[Route("/api/user")]
public class UserController : ControllerBase
{
    private readonly UserDbContext _context;
    private readonly IJwtTokenGenerator _generator;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserController(
        UserDbContext context,
        IJwtTokenGenerator generator,
        IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _generator = generator;
        _passwordHasher = passwordHasher;
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Authenticate(LoginRequest loginRequest)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(user => user.Username == loginRequest.Username);

        if (user == null)
        {
            return Unauthorized("Invalid username or password.");
        }

        var verified = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginRequest.Password);
        if (verified == PasswordVerificationResult.Failed)
        {
            return Unauthorized("Invalid username or password.");
        }

        return Ok(_generator.GenerateToken(user));
    }

    [HttpPost("register")]
    public async Task<ActionResult<string>> Register(RegisterRequest registerRequest)
    {
        var existingUser = await _context.Users
            .FirstOrDefaultAsync(user => user.Username == registerRequest.Username);

        if (existingUser != null)
        {
            return BadRequest("Username is already taken.");
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = registerRequest.Username
        };
        user.PasswordHash = _passwordHasher.HashPassword(user, registerRequest.Password);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(_generator.GenerateToken(user));
    }
}