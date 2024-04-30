using AutoFixture;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Test.Common.Customizations;

public class DisconnectedCustomerCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize<Customer>(composer => composer
            .Without(c => c.Reservations));
    }
}