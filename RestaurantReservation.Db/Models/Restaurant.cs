namespace RestaurantReservation.Db.Models;

public class Restaurant
{
    public int RestaurantId { get; set; }

    public required string Name { get; set; }

    public required string Address { get; set; }

    public required string PhoneNumber { get; set; }

    public required string OpeningHours { get; set; }

    public ICollection<MenuItem> MenuItems { get; set; } = [];

    public ICollection<Employee> Employees { get; set; } = [];

    public ICollection<Table> Tables { get; set; } = [];
}