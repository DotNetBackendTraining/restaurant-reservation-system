using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Test;

public class RestaurantReservationDbContextIntegrationTests
{
    [Theory, AutoData]
    public void CustomerDbSet_AddCustomer_AddsAndTracksCustomerCorrectly(Customer customer)
    {
        var options = new DbContextOptionsBuilder<RestaurantReservationDbContext>()
            .UseInMemoryDatabase(nameof(CustomerDbSet_AddCustomer_AddsAndTracksCustomerCorrectly))
            .Options;
        using var context = new RestaurantReservationDbContext(options);
        customer.CustomerId = 0;

        context.Customers.Add(customer);
        context.SaveChanges();

        context.Customers.FirstOrDefault().Should().BeEquivalentTo(customer);
        customer.CustomerId.Should().NotBe(0);
    }

    [Theory, AutoData]
    public void RestaurantDbSet_AddRestaurant_AddsAndTracksRestaurantCorrectly(Restaurant restaurant)
    {
        var options = new DbContextOptionsBuilder<RestaurantReservationDbContext>()
            .UseInMemoryDatabase(nameof(CustomerDbSet_AddCustomer_AddsAndTracksCustomerCorrectly))
            .Options;
        using var context = new RestaurantReservationDbContext(options);
        restaurant.RestaurantId = 0;

        context.Restaurants.Add(restaurant);
        context.SaveChanges();

        context.Restaurants.FirstOrDefault().Should().BeEquivalentTo(restaurant);
        restaurant.RestaurantId.Should().NotBe(0);
    }
}