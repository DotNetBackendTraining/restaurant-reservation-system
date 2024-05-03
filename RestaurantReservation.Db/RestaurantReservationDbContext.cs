using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Db;

public class RestaurantReservationDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Restaurant> Restaurants { get; set; } = null!;
    public DbSet<MenuItem> MenuItems { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Table> Tables { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Reservation> Reservations { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<EmployeeRestaurantDetail> EmployeeRestaurantDetails { get; set; } = null!;
    public DbSet<ReservationDetail> ReservationDetails { get; set; } = null!;

    public RestaurantReservationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.HasDbFunction(typeof(RestaurantReservationDbContext)
                .GetMethod(nameof(GetTotalRevenueByRestaurant), [typeof(int)])!)
            .HasName("GetTotalRevenueByRestaurant");
    }

    public decimal GetTotalRevenueByRestaurant(int restaurantId) => throw new NotSupportedException();
}