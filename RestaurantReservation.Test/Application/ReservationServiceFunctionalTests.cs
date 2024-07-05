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
}