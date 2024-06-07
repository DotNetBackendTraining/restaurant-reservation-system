using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.App.Configuration.Db;
using RestaurantReservation.App.Interfaces.Services;
using RestaurantReservation.App.Services;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Domain.Interfaces.Repositories;

namespace RestaurantReservation.App.Configuration;

public static class ServiceCollectionExtensions
{
    public static void InjectDatabaseConfiguration(this IServiceCollection collection)
    {
        collection.AddSingleton<IDbContextFactory, DefaultDbContextFactory>();
    }

    public static void InjectDatabase(this IServiceCollection collection)
    {
        collection.AddScoped<RestaurantReservationDbContext>(p => p.GetRequiredService<IDbContextFactory>().Create());
    }

    public static void InjectDomain(this IServiceCollection collection)
    {
        collection.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
        collection.AddScoped<IEmployeeRepository, EmployeeRepository>();
        collection.AddScoped<IOrderRepository, OrderRepository>();
        collection.AddScoped<IReservationRepository, ReservationRepository>();
    }

    public static void InjectApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IEmployeeService, EmployeeService>();
        collection.AddScoped<IReservationService, ReservationService>();
        collection.AddScoped<IOrderService, OrderService>();

        collection.AddAutoMapper(Assembly.GetExecutingAssembly());
    }

    /// <summary>
    /// Use this to inject all application services at once.
    /// </summary>
    public static void AddApplicationServices(this IServiceCollection collection)
    {
        collection.InjectDatabaseConfiguration();
        collection.InjectDatabase();
        collection.InjectDomain();
        collection.InjectApplication();
    }
}