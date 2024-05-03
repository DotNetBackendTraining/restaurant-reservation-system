namespace RestaurantReservation.Domain.Models;

public class ReservationDetail
{
    public int ReservationId { get; set; }
    public required DateTime ReservationDate { get; set; }
    public required int PartySize { get; set; }
    public required string CustomerFirstName { get; set; }
    public required string CustomerLastName { get; set; }
    public required string CustomerEmail { get; set; }
    public required string CustomerPhoneNumber { get; set; }
    public required string RestaurantName { get; set; }
    public required string RestaurantAddress { get; set; }
    public required string RestaurantPhoneNumber { get; set; }
    public required string RestaurantOpeningHours { get; set; }
}