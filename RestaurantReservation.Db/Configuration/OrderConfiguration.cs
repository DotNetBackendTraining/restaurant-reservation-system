using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(o => o.TotalAmount).HasColumnType("decimal(18, 2)");

        builder.HasOne(o => o.Employee)
            .WithMany(e => e.Orders)
            .HasForeignKey(o => o.EmployeeId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.ToTable(o => o.HasCheckConstraint("CK_Orders_TotalAmount", "TotalAmount >= 0"));

        builder.HasData(
            new Order
            {
                OrderId = 1,
                EmployeeId = 1,
                OrderDate = new DateTime(2024, 4, 29, 18, 19, 7, 497, DateTimeKind.Local).AddTicks(9073),
                ReservationId = 1,
                TotalAmount = 45.9
            },
            new Order
            {
                OrderId = 2,
                EmployeeId = 2,
                OrderDate = new DateTime(2024, 4, 29, 18, 19, 7, 497, DateTimeKind.Local).AddTicks(9117),
                ReservationId = 2,
                TotalAmount = 22.3
            },
            new Order
            {
                OrderId = 3,
                EmployeeId = 3,
                OrderDate = new DateTime(2024, 4, 29, 18, 19, 7, 497, DateTimeKind.Local).AddTicks(9120),
                ReservationId = 3,
                TotalAmount = 98.6
            },
            new Order
            {
                OrderId = 4,
                EmployeeId = 4,
                OrderDate = new DateTime(2024, 4, 29, 18, 19, 7, 497, DateTimeKind.Local).AddTicks(9122),
                ReservationId = 4,
                TotalAmount = 33.5
            },
            new Order
            {
                OrderId = 5,
                EmployeeId = 5,
                OrderDate = new DateTime(2024, 4, 29, 18, 19, 7, 497, DateTimeKind.Local).AddTicks(9124),
                ReservationId = 5,
                TotalAmount = 57.75
            });
    }
}