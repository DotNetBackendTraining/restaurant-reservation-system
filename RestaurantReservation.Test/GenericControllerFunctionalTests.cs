using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Presentation.Interfaces;
using RestaurantReservation.Test.Fixtures;
using FluentAssertions;
using RestaurantReservation.Db.Configuration;

namespace RestaurantReservation.Test;

public class ProgramFunctionalTests : IClassFixture<FullTestSetupFixture>
{
    private readonly IGenericController _genericController;

    public ProgramFunctionalTests(FullTestSetupFixture fullTestSetupFixture)
    {
        _genericController = fullTestSetupFixture.ServiceProvider.GetRequiredService<IGenericController>();
    }

    [Fact]
    public async Task ListManagers_ShouldReturnCorrectData()
    {
        var managers = await _genericController.ListManagers().ToListAsync();
        managers.Count.Should().Be(1);
        managers[0].Should().BeEquivalentTo(ModelsData.Employees().ToList()[0]);
    }

    [Fact]
    public async Task GetReservationsByCustomer_ShouldReturnCorrectData()
    {
        var reservations = await _genericController.GetReservationsByCustomer(1).ToListAsync();
        reservations.Count.Should().Be(1);
        reservations[0].Should().BeEquivalentTo(ModelsData.Reservations().ToList()[0]);
    }

    [Fact]
    public async Task ListOrdersAndMenuItems_ShouldReturnCorrectData()
    {
        var pairs = await _genericController.ListOrdersAndMenuItems(1).ToListAsync();
        pairs.Count.Should().Be(1);

        var (order, menuItems) = pairs[0];
        order.Should().BeEquivalentTo(ModelsData.Orders().ToList()[0]);

        var menuItemList = await menuItems.ToListAsync();
        menuItemList.Count.Should().Be(1);
        menuItemList[0].Should().BeEquivalentTo(ModelsData.MenuItems().ToList()[0]);
    }

    [Fact]
    public async Task ListOrderedMenuItems_ShouldReturnCorrectData()
    {
        var menuItems = await _genericController.ListOrderedMenuItems(1).ToListAsync();
        menuItems.Count.Should().Be(1);
        menuItems[0].Should().BeEquivalentTo(ModelsData.MenuItems().ToList()[0]);
    }

    [Fact]
    public async Task CalculateAverageOrderAmount_ShouldReturnCorrectData()
    {
        var average = await _genericController.CalculateAverageOrderAmount(1);
        average.Should().BeApproximately(45.9, 1e-6);
    }
}