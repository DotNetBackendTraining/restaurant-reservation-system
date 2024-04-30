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

        builder.HasData(
            new Reservation
            {
                ReservationId = 1,
                CustomerId = 1,
                PartySize = 4,
                ReservationDate = new DateTime(2024, 4, 29, 19, 0, 0, 0, DateTimeKind.Local),
                TableId = 1
            },
            new Reservation
            {
                ReservationId = 2,
                CustomerId = 2,
                PartySize = 2,
                ReservationDate = new DateTime(2024, 4, 29, 20, 0, 0, 0, DateTimeKind.Local),
                TableId = 2
            },
            new Reservation
            {
                ReservationId = 3,
                CustomerId = 3,
                PartySize = 6,
                ReservationDate = new DateTime(2024, 4, 29, 21, 0, 0, 0, DateTimeKind.Local),
                TableId = 3
            },
            new Reservation
            {
                ReservationId = 4,
                CustomerId = 4,
                PartySize = 3,
                ReservationDate = new DateTime(2024, 4, 29, 18, 0, 0, 0, DateTimeKind.Local),
                TableId = 4
            },
            new Reservation
            {
                ReservationId = 5,
                CustomerId = 5,
                PartySize = 5,
                ReservationDate = new DateTime(2024, 4, 29, 22, 0, 0, 0, DateTimeKind.Local),
                TableId = 5
            }
        );
    }
}