using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Db.Configuration;

public class TableConfiguration : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.ToTable(t => t.HasCheckConstraint("CK_Tables_Capacity", "Capacity >= 0"));

        builder.HasData(ModelsData.Tables());
    }
}