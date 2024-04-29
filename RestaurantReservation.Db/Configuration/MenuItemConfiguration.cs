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

        builder.HasData(
            new MenuItem
            {
                ItemId = 1, RestaurantId = 1, Name = "Cheese Pizza", Description = "Large pizza with extra cheese",
                Price = 15.99
            },
            new MenuItem
            {
                ItemId = 2, RestaurantId = 1, Name = "Veggie Burger", Description = "Burger with gourmet veggies",
                Price = 12.50
            },
            new MenuItem
            {
                ItemId = 3, RestaurantId = 2, Name = "Steak", Description = "Ribeye steak with garlic butter",
                Price = 25.75
            },
            new MenuItem
            {
                ItemId = 4, RestaurantId = 2, Name = "Spaghetti Carbonara",
                Description = "Pasta with creamy sauce and pancetta", Price = 14.50
            },
            new MenuItem
            {
                ItemId = 5, RestaurantId = 3, Name = "Caesar Salad",
                Description = "Crisp romaine lettuce with Caesar dressing", Price = 10.00
            }
        );
    }
}