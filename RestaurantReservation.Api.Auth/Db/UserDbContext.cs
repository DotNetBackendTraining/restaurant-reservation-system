using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Api.Auth.Models;

namespace RestaurantReservation.Api.Auth.Db;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}