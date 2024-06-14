using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Api.Auth.Models;

namespace RestaurantReservation.Api.Auth.Db;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(256);
            entity.HasIndex(e => e.Username)
                .IsUnique();
            entity.Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(256);
            entity.Property(e => e.Role)
                .IsRequired()
                .HasMaxLength(100);
        });
    }
}