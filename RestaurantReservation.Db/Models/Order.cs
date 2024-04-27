namespace RestaurantReservation.Db.Models;

public class Order
{
    public int OrderId { get; set; }

    public required int ReservationId { get; set; }
    public Reservation Reservation { get; set; }

    public int? EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public required DateTime OrderDate { get; set; }

    public required double TotalAmount { get; set; }
}