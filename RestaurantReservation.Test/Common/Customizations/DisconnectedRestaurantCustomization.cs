using AutoFixture;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Test.Common.Customizations;

public class DisconnectedRestaurantCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize<Restaurant>(composer => composer
            .Without(r => r.MenuItems)
            .Without(r => r.Employees)
            .Without(r => r.Tables));
    }
}