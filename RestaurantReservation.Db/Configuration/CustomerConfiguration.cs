using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(c => c.FirstName).HasMaxLength(100);
        builder.Property(c => c.LastName).HasMaxLength(100);
        builder.Property(c => c.Email).HasMaxLength(255);
        builder.Property(c => c.PhoneNumber).HasMaxLength(15);

        builder.HasIndex(c => c.Email).IsUnique();

        builder.HasData(
            new Customer
            {
                CustomerId = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@example.com",
                PhoneNumber = "123-456-7890"
            },
            new Customer
            {
                CustomerId = 2, FirstName = "Jane", LastName = "Smith", Email = "janesmith@example.com",
                PhoneNumber = "234-567-8901"
            },
            new Customer
            {
                CustomerId = 3, FirstName = "Bob", LastName = "Johnson", Email = "bobjohnson@example.com",
                PhoneNumber = "345-678-9012"
            },
            new Customer
            {
                CustomerId = 4, FirstName = "Alice", LastName = "Williams", Email = "alicewilliams@example.com",
                PhoneNumber = "456-789-0123"
            },
            new Customer
            {
                CustomerId = 5, FirstName = "Steve", LastName = "Brown", Email = "stevebrown@example.com",
                PhoneNumber = "567-890-1234"
            }
        );
    }
}