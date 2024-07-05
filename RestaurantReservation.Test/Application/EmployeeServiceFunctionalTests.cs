using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.App.Interfaces.Services;
using RestaurantReservation.Db.Configuration;
using RestaurantReservation.Test.Common.Fixtures;

namespace RestaurantReservation.Test.Application;

public class EmployeeServiceFunctionalTests : IClassFixture<FullTestSetupFixture>
{
    private readonly IEmployeeService _employeeService;

    public EmployeeServiceFunctionalTests(FullTestSetupFixture fullTestSetupFixture)
    {
        _employeeService = fullTestSetupFixture.ServiceProvider.GetRequiredService<IEmployeeService>();
    }

    [Fact]
    public async Task GetAllManagersAsync_ShouldReturnCorrectData()
    {
        var result = await _employeeService.GetAllManagersAsync();
        result.IsSuccess.Should().BeTrue();
        var managers = result.GetDataOrThrow().ToList();
        managers.Count.Should().Be(1);
        managers[0].Should().BeEquivalentTo(ModelsData.Employees().ToList()[0], options => options
            .ExcludingMissingMembers());
    }

    [Fact]
    public async Task CalculateAverageOrderAmount_ShouldReturnCorrectData()
    {
        var result = await _employeeService.CalculateAverageOrderAmountAsync(1);
        result.IsSuccess.Should().BeTrue();
        var average = result.GetDataOrThrow();
        average.Should().BeApproximately(45.9, 1e-6);
    }
}