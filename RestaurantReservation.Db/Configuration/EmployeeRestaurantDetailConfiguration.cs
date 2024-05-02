using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Configuration;

public class EmployeeRestaurantDetailConfiguration : IEntityTypeConfiguration<EmployeeRestaurantDetail>
{
    public void Configure(EntityTypeBuilder<EmployeeRestaurantDetail> builder)
    {
        builder.ToView("EmployeeRestaurantDetailsView");
        builder.HasKey(e => e.EmployeeId);

        builder.Property(e => e.EmployeeFirstName).HasMaxLength(100);
        builder.Property(e => e.EmployeeLastName).HasMaxLength(100);
        builder.Property(e => e.EmployeePosition).HasMaxLength(50);

        builder.Property(r => r.RestaurantName).HasMaxLength(200);
        builder.Property(r => r.RestaurantAddress).HasMaxLength(200);
        builder.Property(r => r.RestaurantPhoneNumber).HasMaxLength(15);
        builder.Property(r => r.RestaurantOpeningHours).HasMaxLength(500);
    }
}