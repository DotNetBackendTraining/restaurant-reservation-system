using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Presentation.Extensions;
using RestaurantReservation.Presentation.Interfaces;

// Build Configuration
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var databaseConfiguration = configuration.GetSection("Database");

// Inject Dependencies
var services = new ServiceCollection();
services.InjectDatabase(databaseConfiguration);
services.InjectPresentation();
var provider = services.BuildServiceProvider();

// Start Application...

// Either, run generic tasks automatically:
await provider.GetRequiredService<IExecutor>().Execute();

// Or, add and run any specific tasks manually...