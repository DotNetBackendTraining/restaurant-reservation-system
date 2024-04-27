using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db;

public class RestaurantReservationDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Restaurant> Restaurants { get; set; } = null!;
    public DbSet<MenuItem> MenuItems { get; set; } = null!;

    public RestaurantReservationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}