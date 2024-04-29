using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db;
using RestaurantReservation.Presentation.Extensions;

// Build Configuration
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var databaseConfiguration = configuration.GetSection("Database");

// Inject Dependencies
var services = new ServiceCollection();
services.InjectDatabase(databaseConfiguration);
var provider = services.BuildServiceProvider();

// Start Application
using var context = provider.GetRequiredService<RestaurantReservationDbContext>();