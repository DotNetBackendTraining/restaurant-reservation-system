using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Configuration;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasOne(r => r.Table)
            .WithMany(t => t.Reservations)
            .HasForeignKey(r => r.TableId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(r => r.HasCheckConstraint("CK_Reservations_PartySize", "PartySize > 0"));

        builder.HasData(ModelsData.Reservations());
    }
}