using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Configuration;

public class TableConfiguration : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.ToTable(t => t.HasCheckConstraint("CK_Tables_Capacity", "Capacity >= 0"));

        builder.HasData(
            new Table { TableId = 1, RestaurantId = 1, Capacity = 4 },
            new Table { TableId = 2, RestaurantId = 1, Capacity = 2 },
            new Table { TableId = 3, RestaurantId = 2, Capacity = 6 },
            new Table { TableId = 4, RestaurantId = 2, Capacity = 4 },
            new Table { TableId = 5, RestaurantId = 3, Capacity = 8 }
        );
    }
}