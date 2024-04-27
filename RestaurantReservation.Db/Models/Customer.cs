namespace RestaurantReservation.Db.Models;

public class Customer
{
    public int CustomerId { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set; }

    public required string PhoneNumber { get; set; }

    public ICollection<Reservation> Reservations { get; set; } = [];
}