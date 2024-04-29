using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Configuration;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable(i => i.HasCheckConstraint("CK_OrderItems_Quantity", "Quantity >= 0"));

        builder.HasData(
            new OrderItem { OrderItemId = 1, OrderId = 1, MenuItemId = 1, Quantity = 2 },
            new OrderItem { OrderItemId = 2, OrderId = 2, MenuItemId = 2, Quantity = 1 },
            new OrderItem { OrderItemId = 3, OrderId = 3, MenuItemId = 3, Quantity = 4 },
            new OrderItem { OrderItemId = 4, OrderId = 4, MenuItemId = 4, Quantity = 3 },
            new OrderItem { OrderItemId = 5, OrderId = 5, MenuItemId = 5, Quantity = 5 }
        );
    }
}