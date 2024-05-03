using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Domain.Models;

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

        builder.HasData(ModelsData.Orders());
    }
}