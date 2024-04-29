using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Configuration;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.Property(r => r.Name).HasMaxLength(200);
        builder.Property(r => r.Address).HasMaxLength(200);
        builder.Property(r => r.PhoneNumber).HasMaxLength(15);
        builder.Property(r => r.OpeningHours).HasMaxLength(500);

        builder.HasData(
            new Restaurant
            {
                RestaurantId = 1, Name = "Good Eats", Address = "123 Main St", PhoneNumber = "987-654-3210",
                OpeningHours = "9:00 AM - 9:00 PM"
            },
            new Restaurant
            {
                RestaurantId = 2, Name = "The Food Place", Address = "456 Side St", PhoneNumber = "876-543-2109",
                OpeningHours = "10:00 AM - 10:00 PM"
            },
            new Restaurant
            {
                RestaurantId = 3, Name = "Dine Fine", Address = "789 Off Rd", PhoneNumber = "765-432-1098",
                OpeningHours = "8:00 AM - 8:00 PM"
            },
            new Restaurant
            {
                RestaurantId = 4, Name = "The Quiet Bite", Address = "321 Fourth St", PhoneNumber = "654-321-0987",
                OpeningHours = "7:00 AM - 7:00 PM"
            },
            new Restaurant
            {
                RestaurantId = 5, Name = "Spice Town", Address = "654 Fifth Ave", PhoneNumber = "543-210-9876",
                OpeningHours = "11:00 AM - 11:00 PM"
            }
        );
    }
}