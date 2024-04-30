using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Presentation.Interfaces;

namespace RestaurantReservation.Presentation.Controllers;

public class GenericController : IGenericController
{
    private readonly IDbContextFactory _factory;

    public GenericController(IDbContextFactory factory)
    {
        _factory = factory;
    }

    public async IAsyncEnumerable<Employee> ListManagers()
    {
        await using var context = _factory.Create();
        var query = context.Employees
            .Where(employee => employee.Position == "Manager")
            .AsAsyncEnumerable();

        await foreach (var manager in query)
        {
            yield return manager;
        }
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
            var menuItems = context.OrderItems
                .Where(oi => oi.OrderId == order.OrderId)
                .Select(od => od.MenuItem)
                .AsAsyncEnumerable();

            yield return (order, menuItems);
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