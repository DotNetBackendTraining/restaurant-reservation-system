using RestaurantReservation.Presentation.Interfaces;

namespace RestaurantReservation.Presentation.Services;

/// <summary>
/// Uses reflection to automatically list (bind) all methods of the controller to the user (UI),
/// prompt to choose one, then executes it and prints the results.
/// Use it for controllers which all methods return a printable value (or a list), or perform an action (void).
/// Since reflection won't be able to provide any feedback after the method other than printing the results.
/// Or deal with complex results.
/// </summary>
/// <typeparam name="TController"></typeparam>
public class DynamicExecutor<TController> : IExecutor
{
    private readonly TController _controller;

    public DynamicExecutor(TController controller)
    {
        _controller = controller;
    }

    public async Task Execute()
    {
        var methods = typeof(IGenericController).GetMethods();
        while (true)
        {
            for (var i = 0; i < methods.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {methods[i].Name}");
            }

            Console.WriteLine("Choose an action (or type anything else to quit):");
            var input = Console.ReadLine() ?? string.Empty;
            if (!(int.TryParse(input, out var choice) && choice > 0 && choice <= methods.Length))
                break;

            var method = methods[choice - 1];
            var parameters = new List<object>();

            foreach (var param in method.GetParameters())
            {
                Console.WriteLine($"Enter {param.Name} ({param.ParameterType.Name}):");
                var paramInput = Console.ReadLine() ?? string.Empty;
                var paramValue = Convert.ChangeType(paramInput, param.ParameterType);
                parameters.Add(paramValue);
            }

            var result = method.Invoke(_controller, parameters.ToArray());

            if (result is IAsyncEnumerable<object> asyncEnumerable)
            {
                await foreach (var item in asyncEnumerable)
                {
                    Console.WriteLine(item);
                }

                continue;
            }

            if (result is Task task)
            {
                await task;

                var resultProperty = task.GetType().GetProperty("Result");
                if (resultProperty != null)
                {
                    // Get the result of a Task<T>
                    result = resultProperty.GetValue(task);
                }
            }

            Console.WriteLine(result?.ToString() ?? "Method executed successfully.");
        }
    }
}