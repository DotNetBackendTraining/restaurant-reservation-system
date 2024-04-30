using AutoFixture;
using AutoFixture.Xunit2;

namespace RestaurantReservation.Test.Common;

public class CustomAutoDataAttribute : AutoDataAttribute
{
    public CustomAutoDataAttribute(params Type[] customizationTypes)
        : base(() => CreateFixture(customizationTypes))
    {
    }

    private static Fixture CreateFixture(IEnumerable<Type> customizationTypes)
    {
        var fixture = new Fixture();
        foreach (var type in customizationTypes)
        {
            var instance = Activator.CreateInstance(type) ?? throw new InvalidOperationException();
            var customization = (ICustomization)instance;
            fixture.Customize(customization);
        }

        return fixture;
    }
}