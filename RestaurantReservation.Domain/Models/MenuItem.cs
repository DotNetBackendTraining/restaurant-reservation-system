namespace RestaurantReservation.Domain.Models;

public class MenuItem
{
    public int ItemId { get; set; }

    public required int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public required double Price { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = [];
}