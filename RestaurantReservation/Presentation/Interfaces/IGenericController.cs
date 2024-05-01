using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Presentation.Interfaces;

/// <summary>
/// General controller for miscellaneous tasks that do not fit into a specific category.
/// </summary>
public interface IGenericController
{
    /// <summary>
    /// This method retrieves all employees who hold the position of "Manager."
    /// </summary>
    IAsyncEnumerable<Employee> ListManagers();

    /// <summary>
    /// This method takes a customer identifier as a parameter and returns a list of reservations made by that particular customer.
    /// </summary>
    IAsyncEnumerable<Reservation> GetReservationsByCustomer(int customerId);

    /// <summary>
    /// This method takes a reservation identifier as a parameter and lists the orders placed on that specific reservation along with the associated menu items.
    /// </summary>
    IAsyncEnumerable<(Order, IList<MenuItem>)> ListOrdersAndMenuItems(int reservationId);

    /// <summary>
    /// This method takes a reservation identifier as a parameter and finds the menu items ordered in that specific reservation.
    /// </summary>
    IAsyncEnumerable<MenuItem> ListOrderedMenuItems(int reservationId);

    /// <summary>
    /// This method takes an employee identifier as a parameter and calculates the average order amount for that specific employee.
    /// </summary>
    Task<double> CalculateAverageOrderAmount(int employeeId);
}