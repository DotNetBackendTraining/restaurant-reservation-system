using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Configuration;

public class ReservationDetailConfiguration : IEntityTypeConfiguration<ReservationDetail>
{
    public void Configure(EntityTypeBuilder<ReservationDetail> builder)
    {
        builder.ToView("ReservationDetailsView");
        builder.HasKey(r => r.ReservationId);

        builder.Property(r => r.CustomerFirstName).HasMaxLength(100);
        builder.Property(r => r.CustomerLastName).HasMaxLength(100);
        builder.Property(r => r.CustomerEmail).HasMaxLength(255);
        builder.Property(r => r.CustomerPhoneNumber).HasMaxLength(15);

        builder.Property(r => r.RestaurantName).HasMaxLength(200);
        builder.Property(r => r.RestaurantAddress).HasMaxLength(200);
        builder.Property(r => r.RestaurantPhoneNumber).HasMaxLength(15);
        builder.Property(r => r.RestaurantOpeningHours).HasMaxLength(500);
    }
}