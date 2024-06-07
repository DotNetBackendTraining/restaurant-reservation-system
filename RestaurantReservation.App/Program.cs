using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.App.Configuration;

// Build Configuration
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var databaseConfiguration = configuration.GetSection("Database");

// Inject Dependencies
var services = new ServiceCollection();
services.InjectConfiguration(databaseConfiguration);
services.InjectDatabase();
services.InjectDomain();
services.InjectApplication();
services.InjectPresentation();
var provider = services.BuildServiceProvider();

// Start Application...
