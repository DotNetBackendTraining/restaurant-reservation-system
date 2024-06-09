using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.App.Configuration;
using RestaurantReservation.Db;

namespace RestaurantReservation.Test.Common.Fixtures;

/// <summary>
/// Complete test setup, with all dependencies, and sample database.
/// </summary>
public class FullTestSetupFixture : IDisposable
{
    public IServiceProvider ServiceProvider { get; }

    public FullTestSetupFixture()
    {
        var serviceCollection = new ServiceCollection();
        InjectDatabase(serviceCollection);
        serviceCollection.InjectDomain();
        serviceCollection.InjectApplication();
        ServiceProvider = serviceCollection.BuildServiceProvider();
    }

    private void InjectDatabase(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<DatabaseFixture>();
        serviceCollection.AddSingleton<IDbContextFactory<RestaurantReservationDbContext>>(p =>
            p.GetRequiredService<DatabaseFixture>().ContextFactory);
        serviceCollection.AddScoped<RestaurantReservationDbContext>(p =>
            p.GetRequiredService<IDbContextFactory<RestaurantReservationDbContext>>().CreateDbContext());
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        ServiceProvider.GetRequiredService<DatabaseFixture>().Dispose();
    }
}