using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Domain.Interfaces.Services;
using RestaurantReservation.Presentation.Interfaces;

namespace RestaurantReservation.Presentation.Controllers;

public class GenericController : IGenericController
{
    private readonly IDbContextFactory _factory;
    private readonly IEmployeeService _employeeService;

    public GenericController(
        IDbContextFactory factory,
        IEmployeeService employeeService)
    {
        _factory = factory;
        _employeeService = employeeService;
    }

    public IAsyncEnumerable<Employee> ListManagers()
    {
        return _employeeService.GetAllManagersAsync();
    }

    public async IAsyncEnumerable<Reservation> GetReservationsByCustomer(int customerId)
    {
        await using var context = _factory.Create();
        var query = context.Reservations
            .Where(reservation => reservation.CustomerId == customerId)
            .AsAsyncEnumerable();

        await foreach (var reservation in query)
        {
            yield return reservation;
        }
    }

    public async IAsyncEnumerable<(Order, IAsyncEnumerable<MenuItem>)> ListOrdersAndMenuItems(int reservationId)
    {
        await using var context = _factory.Create();
        var orders = context.Orders
            .Where(o => o.ReservationId == reservationId);

        await foreach (var order in orders.AsAsyncEnumerable())
        {
            var menuItems = await context.OrderItems
                .Where(oi => oi.OrderId == order.OrderId)
                .Select(od => od.MenuItem)
                .Distinct()
                .ToListAsync();

            yield return (order, menuItems.ToAsyncEnumerable());
        }
    }

    public async IAsyncEnumerable<MenuItem> ListOrderedMenuItems(int reservationId)
    {
        await using var context = _factory.Create();
        var query = context.Reservations
            .Where(reservation => reservation.ReservationId == reservationId)
            .SelectMany(reservation => reservation.Orders)
            .SelectMany(order => order.OrderItems)
            .Select(orderItem => orderItem.MenuItem)
            .Distinct();

        await foreach (var menuItem in query.AsAsyncEnumerable())
        {
            yield return menuItem;
        }
    }

    public async Task<double> CalculateAverageOrderAmount(int employeeId)
    {
        await using var context = _factory.Create();
        return await context.Employees
            .Where(e => e.EmployeeId == employeeId)
            .SelectMany(e => e.Orders)
            .AverageAsync(o => o.TotalAmount);
    }
}