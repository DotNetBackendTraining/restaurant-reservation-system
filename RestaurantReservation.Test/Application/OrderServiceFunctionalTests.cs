using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db.Configuration;
using RestaurantReservation.Interfaces.Services;
using RestaurantReservation.Test.Common.Fixtures;

namespace RestaurantReservation.Test.Application;

public class OrderServiceFunctionalTests : IClassFixture<FullTestSetupFixture>
{
    private readonly IOrderService _orderService;

    public OrderServiceFunctionalTests(FullTestSetupFixture fullTestSetupFixture)
    {
        _orderService = fullTestSetupFixture.ServiceProvider.GetRequiredService<IOrderService>();
    }

    [Fact]
    public async Task ListOrdersAndMenuItemsAsync_ShouldReturnCorrectData()
    {
        var pairs = (await _orderService.ListOrdersAndMenuItemsAsync(1)).ToList();
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
        var menuItems = (await _orderService.ListOrderedMenuItemsAsync(1)).ToList();
        menuItems.Count.Should().Be(1);
        menuItems[0].Should().BeEquivalentTo(ModelsData.MenuItems().ToList()[0], options => options
            .ExcludingMissingMembers());
    }
}