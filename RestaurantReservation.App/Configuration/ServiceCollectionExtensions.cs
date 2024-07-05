using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.App.Configuration.Db;
using RestaurantReservation.App.DTOs;
using RestaurantReservation.App.Interfaces.Services;
using RestaurantReservation.App.Services;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Domain.Interfaces.Repositories;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.App.Configuration;

public static class ServiceCollectionExtensions
{
    public static void InjectDatabase(this IServiceCollection collection)
    {
        collection.AddDbContextFactory<RestaurantReservationDbContext, DefaultDbContextFactory>();
        collection.AddScoped<RestaurantReservationDbContext>(p =>
            p.GetRequiredService<IDbContextFactory<RestaurantReservationDbContext>>().CreateDbContext());
    }

    public static void InjectDomain(this IServiceCollection collection)
    {
        collection.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
        collection.AddScoped<IEmployeeRepository, EmployeeRepository>();
        collection.AddScoped<IOrderRepository, OrderRepository>();
        collection.AddScoped<IReservationRepository, ReservationRepository>();
        collection.AddScoped<ICustomerRepository, CustomerRepository>();
    }

    public static void InjectApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IEmployeeService, EmployeeService>();
        collection.AddScoped<IReservationService, ReservationService>();
        collection.AddScoped<IOrderService, OrderService>();
        collection.AddScoped<ICustomerService, CustomerService>();

        collection.AddScoped<ICudService<EmployeeDto>, CudService<EmployeeDto, Employee>>();
        collection.AddScoped<ICudService<MenuItemDto>, CudService<MenuItemDto, MenuItem>>();
        collection.AddScoped<ICudService<OrderDto>, CudService<OrderDto, Order>>();
        collection.AddScoped<ICudService<ReservationDto>, CudService<ReservationDto, Reservation>>();

        collection.AddAutoMapper(Assembly.GetExecutingAssembly());
    }

    /// <summary>
    /// Use this to inject all application services at once.
    /// </summary>
    public static void AddApplicationServices(this IServiceCollection collection)
    {
        collection.InjectDatabase();
        collection.InjectDomain();
        collection.InjectApplication();
    }
}