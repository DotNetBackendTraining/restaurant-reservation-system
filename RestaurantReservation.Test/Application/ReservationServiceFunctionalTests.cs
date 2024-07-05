using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.App.Interfaces.Services;
using RestaurantReservation.Db.Configuration;
using RestaurantReservation.Test.Common.Fixtures;

namespace RestaurantReservation.Test.Application;

public class ReservationServiceFunctionalTests : IClassFixture<FullTestSetupFixture>
{
    private readonly IReservationService _reservationController;

    public ReservationServiceFunctionalTests(FullTestSetupFixture fullTestSetupFixture)
    {
        _reservationController = fullTestSetupFixture.ServiceProvider.GetRequiredService<IReservationService>();
    }

    [Fact]
    public async Task GetReservationsByCustomerAsync_ShouldReturnCorrectData()
    {
        var result = await _reservationController.GetReservationsByCustomerAsync(1);
        var reservations = result.GetDataOrThrow().ToList();
        reservations.Count.Should().Be(1);
        reservations[0].Should().BeEquivalentTo(ModelsData.Reservations().ToList()[0], options => options
            .ExcludingMissingMembers());
    }

    [Fact]
    public async Task ListOrdersAndMenuItemsAsync_ShouldReturnCorrectData()
    {
        var result = await _reservationController.ListOrdersAndMenuItemsAsync(1);
        result.IsSuccess.Should().BeTrue();

        var pairs = result.GetDataOrThrow().ToList();
        pairs.Count.Should().Be(1);

        var (order, menuItems) = pairs[0];
        order.Should().BeEquivalentTo(ModelsData.Orders().ToList()[0], options => options
            .ExcludingMissingMembers());

        menuItems.Count.Should().Be(1);
        menuItems[0].Should().BeEquivalentTo(ModelsData.MenuItems().ToList()[0], options => options
            .ExcludingMissingMembers());
    }

    [Fact]
    public async Task ListOrderedMenuItemsAsync_ShouldReturnCorrectData()
    {
        var result = await _reservationController.ListOrdersAndMenuItemsAsync(1);
        result.IsSuccess.Should().BeTrue();

        var menuItems = result.GetDataOrThrow().ToList();
        menuItems.Count.Should().Be(1);
        menuItems[0].Should().BeEquivalentTo(ModelsData.MenuItems().ToList()[0], options => options
            .ExcludingMissingMembers());
    }
}