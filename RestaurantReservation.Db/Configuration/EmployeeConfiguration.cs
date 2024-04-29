using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(e => e.FirstName).HasMaxLength(100);
        builder.Property(e => e.LastName).HasMaxLength(100);
        builder.Property(e => e.Position).HasMaxLength(50);

        builder.HasData(
            new Employee
                { EmployeeId = 1, RestaurantId = 1, FirstName = "Alice", LastName = "Brown", Position = "Manager" },
            new Employee
                { EmployeeId = 2, RestaurantId = 1, FirstName = "Carlos", LastName = "Davis", Position = "Chef" },
            new Employee
                { EmployeeId = 3, RestaurantId = 2, FirstName = "Eva", LastName = "Green", Position = "Waitress" },
            new Employee
                { EmployeeId = 4, RestaurantId = 2, FirstName = "David", LastName = "Miller", Position = "Bartender" },
            new Employee
                { EmployeeId = 5, RestaurantId = 3, FirstName = "Olivia", LastName = "Wilson", Position = "Hostess" }
        );
    }
}