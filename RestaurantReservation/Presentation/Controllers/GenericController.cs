using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Domain.Interfaces.Services;
using RestaurantReservation.Presentation.Interfaces;

namespace RestaurantReservation.Presentation.Controllers;

public class GenericController : IGenericController
{
    private readonly IDbContextFactory _factory;
    private readonly IEmployeeService _employeeService;
    private readonly IReservationService _reservationService;
    private readonly IOrderService _orderService;

    public GenericController(
        IDbContextFactory factory,
        IEmployeeService employeeService,
        IReservationService reservationService,
        IOrderService orderService)
    {
        _factory = factory;
        _employeeService = employeeService;
        _reservationService = reservationService;
        _orderService = orderService;
    }

    public IAsyncEnumerable<Employee> ListManagers()
    {
        return _employeeService.GetAllManagersAsync();
    }

    public IAsyncEnumerable<Reservation> GetReservationsByCustomer(int customerId)
    {
        return _reservationService.GetReservationsByCustomer(customerId);
    }

    public IAsyncEnumerable<(Order, IList<MenuItem>)> ListOrdersAndMenuItems(int reservationId)
    {
        return _orderService.ListOrdersAndMenuItems(reservationId);
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