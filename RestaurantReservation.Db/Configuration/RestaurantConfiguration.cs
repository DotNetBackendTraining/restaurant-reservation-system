using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Db.Configuration;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.Property(r => r.Name).HasMaxLength(200);
        builder.Property(r => r.Address).HasMaxLength(200);
        builder.Property(r => r.PhoneNumber).HasMaxLength(15);
        builder.Property(r => r.OpeningHours).HasMaxLength(500);

        builder.HasData(ModelsData.Restaurants());
    }
}