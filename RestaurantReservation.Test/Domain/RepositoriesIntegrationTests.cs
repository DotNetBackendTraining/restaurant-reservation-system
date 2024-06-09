using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Domain.Models;
using RestaurantReservation.Test.Common;
using RestaurantReservation.Test.Common.Customizations;
using RestaurantReservation.Test.Common.Services;

namespace RestaurantReservation.Test.Domain;

public class RepositoriesIntegrationTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly IDbContextFactory<RestaurantReservationDbContext> _contextFactory;

    public RepositoriesIntegrationTests()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();
        _contextFactory = new SqliteDbContextFactory(_connection);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _connection.Close();
    }

    [Theory, CustomAutoData(typeof(DisconnectedCustomerCustomization))]
    public async Task AddAndSaveCustomer_ShouldAddNewCustomerCorrectly(Customer customer)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var repository = new CommandRepository<Customer>(context);
        customer.CustomerId = 0;

        // Add
        repository.Add(customer);
        context.Entry(customer).State.Should().Be(EntityState.Added); // has been tracked

        // Check
        var customerBefore = await context.Customers.FindAsync(customer.CustomerId);
        customerBefore.Should().BeNull(); // not added yet

        // Save
        var written = await repository.SaveChangesAsync();
        written.Should().Be(1); // single item added

        // Check
        var customerAfter = await context.Customers.FindAsync(customer.CustomerId);
        customerAfter.Should().NotBeNull(); // has been added
    }

    [Theory, CustomAutoData(typeof(DisconnectedCustomerCustomization))]
    public async Task AddThenFindCustomer_ShouldReturnNullBeforeSaveAndCustomerAfterSave(Customer customer)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var commandRepository = new CommandRepository<Customer>(context);
        customer.CustomerId = 0;

        // Add
        commandRepository.Add(customer);

        // Return null
        var customerBefore = await context.FindAsync<Customer>(customer.CustomerId);
        customerBefore.Should().BeNull();

        // Save
        await commandRepository.SaveChangesAsync();

        // Return customer
        var customerAfter = await context.FindAsync<Customer>(customer.CustomerId);
        customerAfter.Should().BeEquivalentTo(customer);
    }
}