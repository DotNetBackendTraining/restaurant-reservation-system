namespace RestaurantReservation.Domain.Models;

public class Table
{
    public int TableId { get; set; }

    public required int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }

    public required int Capacity { get; set; }

    public ICollection<Reservation> Reservations { get; set; } = [];
}