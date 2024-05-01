using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Configuration;

public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder.HasKey(i => i.ItemId);

        builder.Property(i => i.Name).HasMaxLength(100);
        builder.Property(i => i.Description).HasMaxLength(500);
        builder.Property(i => i.Price).HasColumnType("decimal(18,2)");

        builder.ToTable(i => i.HasCheckConstraint("CK_MenuItems_Price", "Price >= 0"));

        builder.HasData(ModelsData.MenuItems());
    }
}