using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Application.Interfaces.Services;
using RestaurantReservation.Application.Services;
using RestaurantReservation.Db;
using RestaurantReservation.Domain.Interfaces.Repositories;
using RestaurantReservation.Domain.Repositories;
using RestaurantReservation.Presentation.Controllers;
using RestaurantReservation.Presentation.Interfaces;
using RestaurantReservation.Presentation.Services;

namespace RestaurantReservation.Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static void InjectConfiguration(this IServiceCollection collection, IConfiguration databaseConfiguration)
    {
        collection.AddSingleton<IDbContextFactory>(_ => new DefaultDbContextFactory(databaseConfiguration));
    }

    public static void InjectDatabase(this IServiceCollection collection)
    {
        collection.AddScoped<RestaurantReservationDbContext>(p => p.GetRequiredService<IDbContextFactory>().Create());
    }

    public static void InjectDomain(this IServiceCollection collection)
    {
        collection.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
        collection.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
    }

    public static void InjectApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IEmployeeService, EmployeeService>();
        collection.AddScoped<IReservationService, ReservationService>();
        collection.AddScoped<IOrderService, OrderService>();
    }

    public static void InjectPresentation(this IServiceCollection collection)
    {
        collection.AddScoped<IGenericController, GenericController>();
    }
}