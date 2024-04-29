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
                ReservationId = 1, CustomerId = 1, TableId = 1, ReservationDate = DateTime.Today.AddHours(19),
                PartySize = 4
            },
            new Reservation
            {
                ReservationId = 2, CustomerId = 2, TableId = 2, ReservationDate = DateTime.Today.AddHours(20),
                PartySize = 2
            },
            new Reservation
            {
                ReservationId = 3, CustomerId = 3, TableId = 3, ReservationDate = DateTime.Today.AddHours(21),
                PartySize = 6
            },
            new Reservation
            {
                ReservationId = 4, CustomerId = 4, TableId = 4, ReservationDate = DateTime.Today.AddHours(18),
                PartySize = 3
            },
            new Reservation
            {
                ReservationId = 5, CustomerId = 5, TableId = 5, ReservationDate = DateTime.Today.AddHours(22),
                PartySize = 5
            }
        );
    }
}