namespace RestaurantReservation.Db.Models;

public class OrderItem
{
    public int OrderItemId { get; set; }

    public required int OrderId { get; set; }
    public Order Order { get; set; }

    public required int MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; }

    public required int Quantity { get; set; }
}