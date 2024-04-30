using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db;
using RestaurantReservation.Presentation.Extensions;
using RestaurantReservation.Presentation.Interfaces;
using RestaurantReservation.Test.Data;
using RestaurantReservation.Test.Services;

namespace RestaurantReservation.Test.Fixtures;

/// <summary>
/// Complete test setup, with all dependencies, and sample database.
/// </summary>
public class FullTestSetupFixture
{
    public IServiceProvider ServiceProvider { get; }

    public FullTestSetupFixture()
    {
        var serviceCollection = new ServiceCollection();

        InjectConfiguration(serviceCollection); // Test configuration
        serviceCollection.InjectDatabase();
        serviceCollection.InjectPresentation();
        ServiceProvider = serviceCollection.BuildServiceProvider();

        SeedData();
    }

    private void InjectConfiguration(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IDbContextFactory, SqliteDbContextFactory>();
    }

    private void SeedData()
    {
        using var context = ServiceProvider.GetRequiredService<RestaurantReservationDbContext>();
        context.Database.EnsureCreated();

        if (!context.Customers.Any())
        {
            context.Customers.AddRange(ModelsData.Customers());
        }

        if (!context.Employees.Any())
        {
            context.Employees.AddRange(ModelsData.Employees());
        }

        if (!context.MenuItems.Any())
        {
            context.MenuItems.AddRange(ModelsData.MenuItems());
        }

        if (!context.Orders.Any())
        {
            context.Orders.AddRange(ModelsData.Orders());
        }

        if (!context.OrderItems.Any())
        {
            context.OrderItems.AddRange(ModelsData.OrderItems());
        }

        if (!context.Reservations.Any())
        {
            context.Reservations.AddRange(ModelsData.Reservations());
        }

        if (!context.Restaurants.Any())
        {
            context.Restaurants.AddRange(ModelsData.Restaurants());
        }

        if (!context.Tables.Any())
        {
            context.Tables.AddRange(ModelsData.Tables());
        }

        context.SaveChanges();
    }
}