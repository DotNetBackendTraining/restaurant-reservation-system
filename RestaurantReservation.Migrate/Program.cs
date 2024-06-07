using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestaurantReservation.Db;

var config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .Build();

var optionsBuilder = new DbContextOptionsBuilder<RestaurantReservationDbContext>();
optionsBuilder.UseSqlServer(config.GetSection("DatabaseSettings")["ConnectionString"]);

using var context = new RestaurantReservationDbContext(optionsBuilder.Options);
Console.WriteLine("Applying migrations...");
context.Database.Migrate();
Console.WriteLine("Migrations applied successfully.");