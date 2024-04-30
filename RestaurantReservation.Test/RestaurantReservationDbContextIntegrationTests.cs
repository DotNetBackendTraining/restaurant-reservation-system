using FluentAssertions;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Test.Common;
using RestaurantReservation.Test.Common.Customizations;
using RestaurantReservation.Test.Services;

namespace RestaurantReservation.Test;

public class RestaurantReservationDbContextIntegrationTests
{
    [Theory, CustomAutoData(typeof(DisconnectedCustomerCustomization))]
    public void CustomerDbSet_AddCustomer_AddsAndTracksCustomerCorrectly(Customer customer)
    {
        using var context = InMemoryDbContextFactory.CreateDbContext(
            nameof(CustomerDbSet_AddCustomer_AddsAndTracksCustomerCorrectly));
        customer.CustomerId = 0;

        context.Customers.Add(customer);
        context.SaveChanges();

        context.Customers.FirstOrDefault().Should().BeEquivalentTo(customer);
        customer.CustomerId.Should().NotBe(0);
    }

    [Theory, CustomAutoData(typeof(DisconnectedRestaurantCustomization))]
    public void RestaurantDbSet_AddRestaurant_AddsAndTracksRestaurantCorrectly(Restaurant restaurant)
    {
        using var context = InMemoryDbContextFactory.CreateDbContext(
            nameof(RestaurantDbSet_AddRestaurant_AddsAndTracksRestaurantCorrectly));
        restaurant.RestaurantId = 0;

        context.Restaurants.Add(restaurant);
        context.SaveChanges();

        context.Restaurants.FirstOrDefault().Should().BeEquivalentTo(restaurant);
        restaurant.RestaurantId.Should().NotBe(0);
    }
}