using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Db.Configuration;

public static class ModelsData
{
    public static IEnumerable<Customer> Customers()
    {
        yield return new Customer
        {
            CustomerId = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@example.com",
            PhoneNumber = "123-456-7890"
        };
        yield return new Customer
        {
            CustomerId = 2, FirstName = "Jane", LastName = "Smith", Email = "janesmith@example.com",
            PhoneNumber = "234-567-8901"
        };
        yield return new Customer
        {
            CustomerId = 3, FirstName = "Bob", LastName = "Johnson", Email = "bobjohnson@example.com",
            PhoneNumber = "345-678-9012"
        };
        yield return new Customer
        {
            CustomerId = 4, FirstName = "Alice", LastName = "Williams", Email = "alicewilliams@example.com",
            PhoneNumber = "456-789-0123"
        };
        yield return new Customer
        {
            CustomerId = 5, FirstName = "Steve", LastName = "Brown", Email = "stevebrown@example.com",
            PhoneNumber = "567-890-1234"
        };
    }

    public static IEnumerable<Employee> Employees()
    {
        yield return new Employee
            { EmployeeId = 1, RestaurantId = 1, FirstName = "Alice", LastName = "Brown", Position = "Manager" };
        yield return new Employee
            { EmployeeId = 2, RestaurantId = 1, FirstName = "Carlos", LastName = "Davis", Position = "Chef" };
        yield return new Employee
            { EmployeeId = 3, RestaurantId = 2, FirstName = "Eva", LastName = "Green", Position = "Waitress" };
        yield return new Employee
            { EmployeeId = 4, RestaurantId = 2, FirstName = "David", LastName = "Miller", Position = "Bartender" };
        yield return new Employee
            { EmployeeId = 5, RestaurantId = 3, FirstName = "Olivia", LastName = "Wilson", Position = "Hostess" };
    }

    public static IEnumerable<MenuItem> MenuItems()
    {
        yield return new MenuItem
        {
            ItemId = 1, RestaurantId = 1, Name = "Cheese Pizza", Description = "Large pizza with extra cheese",
            Price = 15.99
        };
        yield return new MenuItem
        {
            ItemId = 2, RestaurantId = 1, Name = "Veggie Burger", Description = "Burger with gourmet veggies",
            Price = 12.50
        };
        yield return new MenuItem
        {
            ItemId = 3, RestaurantId = 2, Name = "Steak", Description = "Ribeye steak with garlic butter",
            Price = 25.75
        };
        yield return new MenuItem
        {
            ItemId = 4, RestaurantId = 2, Name = "Spaghetti Carbonara",
            Description = "Pasta with creamy sauce and pancetta", Price = 14.50
        };
        yield return new MenuItem
        {
            ItemId = 5, RestaurantId = 3, Name = "Caesar Salad",
            Description = "Crisp romaine lettuce with Caesar dressing", Price = 10.00
        };
    }

    public static IEnumerable<Order> Orders()
    {
        yield return new Order
        {
            OrderId = 1,
            EmployeeId = 1,
            OrderDate = new DateTime(2024, 4, 29, 18, 19, 7, 497, DateTimeKind.Local).AddTicks(9073),
            ReservationId = 1,
            TotalAmount = 45.9
        };
        yield return new Order
        {
            OrderId = 2,
            EmployeeId = 2,
            OrderDate = new DateTime(2024, 4, 29, 18, 19, 7, 497, DateTimeKind.Local).AddTicks(9117),
            ReservationId = 2,
            TotalAmount = 22.3
        };
        yield return new Order
        {
            OrderId = 3,
            EmployeeId = 3,
            OrderDate = new DateTime(2024, 4, 29, 18, 19, 7, 497, DateTimeKind.Local).AddTicks(9120),
            ReservationId = 3,
            TotalAmount = 98.6
        };
        yield return new Order
        {
            OrderId = 4,
            EmployeeId = 4,
            OrderDate = new DateTime(2024, 4, 29, 18, 19, 7, 497, DateTimeKind.Local).AddTicks(9122),
            ReservationId = 4,
            TotalAmount = 33.5
        };
        yield return new Order
        {
            OrderId = 5,
            EmployeeId = 5,
            OrderDate = new DateTime(2024, 4, 29, 18, 19, 7, 497, DateTimeKind.Local).AddTicks(9124),
            ReservationId = 5,
            TotalAmount = 57.75
        };
    }

    public static IEnumerable<OrderItem> OrderItems()
    {
        yield return new OrderItem { OrderItemId = 1, OrderId = 1, MenuItemId = 1, Quantity = 2 };
        yield return new OrderItem { OrderItemId = 2, OrderId = 2, MenuItemId = 2, Quantity = 1 };
        yield return new OrderItem { OrderItemId = 3, OrderId = 3, MenuItemId = 3, Quantity = 4 };
        yield return new OrderItem { OrderItemId = 4, OrderId = 4, MenuItemId = 4, Quantity = 3 };
        yield return new OrderItem { OrderItemId = 5, OrderId = 5, MenuItemId = 5, Quantity = 5 };
    }

    public static IEnumerable<Reservation> Reservations()
    {
        yield return new Reservation
        {
            ReservationId = 1,
            CustomerId = 1,
            PartySize = 4,
            ReservationDate = new DateTime(2024, 4, 29, 19, 0, 0, 0, DateTimeKind.Local),
            TableId = 1
        };
        yield return new Reservation
        {
            ReservationId = 2,
            CustomerId = 2,
            PartySize = 2,
            ReservationDate = new DateTime(2024, 4, 29, 20, 0, 0, 0, DateTimeKind.Local),
            TableId = 2
        };
        yield return new Reservation
        {
            ReservationId = 3,
            CustomerId = 3,
            PartySize = 6,
            ReservationDate = new DateTime(2024, 4, 29, 21, 0, 0, 0, DateTimeKind.Local),
            TableId = 3
        };
        yield return new Reservation
        {
            ReservationId = 4,
            CustomerId = 4,
            PartySize = 3,
            ReservationDate = new DateTime(2024, 4, 29, 18, 0, 0, 0, DateTimeKind.Local),
            TableId = 4
        };
        yield return new Reservation
        {
            ReservationId = 5,
            CustomerId = 5,
            PartySize = 5,
            ReservationDate = new DateTime(2024, 4, 29, 22, 0, 0, 0, DateTimeKind.Local),
            TableId = 5
        };
    }

    public static IEnumerable<Restaurant> Restaurants()
    {
        yield return new Restaurant
        {
            RestaurantId = 1, Name = "Good Eats", Address = "123 Main St", PhoneNumber = "987-654-3210",
            OpeningHours = "9:00 AM - 9:00 PM"
        };
        yield return new Restaurant
        {
            RestaurantId = 2, Name = "The Food Place", Address = "456 Side St", PhoneNumber = "876-543-2109",
            OpeningHours = "10:00 AM - 10:00 PM"
        };
        yield return new Restaurant
        {
            RestaurantId = 3, Name = "Dine Fine", Address = "789 Off Rd", PhoneNumber = "765-432-1098",
            OpeningHours = "8:00 AM - 8:00 PM"
        };
        yield return new Restaurant
        {
            RestaurantId = 4, Name = "The Quiet Bite", Address = "321 Fourth St", PhoneNumber = "654-321-0987",
            OpeningHours = "7:00 AM - 7:00 PM"
        };
        yield return new Restaurant
        {
            RestaurantId = 5, Name = "Spice Town", Address = "654 Fifth Ave", PhoneNumber = "543-210-9876",
            OpeningHours = "11:00 AM - 11:00 PM"
        };
    }

    public static IEnumerable<Table> Tables()
    {
        yield return new Table { TableId = 1, RestaurantId = 1, Capacity = 4 };
        yield return new Table { TableId = 2, RestaurantId = 1, Capacity = 2 };
        yield return new Table { TableId = 3, RestaurantId = 2, Capacity = 6 };
        yield return new Table { TableId = 4, RestaurantId = 2, Capacity = 4 };
        yield return new Table { TableId = 5, RestaurantId = 3, Capacity = 8 };
    }
}