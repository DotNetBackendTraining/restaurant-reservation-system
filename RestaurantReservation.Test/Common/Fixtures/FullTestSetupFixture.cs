using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.App.Configuration;
using RestaurantReservation.App.Configuration.Db;

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
        InjectDatabaseConfiguration(serviceCollection);
        serviceCollection.InjectDatabase();
        serviceCollection.InjectDomain();
        serviceCollection.InjectApplication();
        ServiceProvider = serviceCollection.BuildServiceProvider();
    }

    private void InjectDatabaseConfiguration(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<DatabaseFixture>();
        serviceCollection.AddSingleton<IDbContextFactory>(p =>
            p.GetRequiredService<DatabaseFixture>().ContextFactory);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        ServiceProvider.GetRequiredService<DatabaseFixture>().Dispose();
    }
}