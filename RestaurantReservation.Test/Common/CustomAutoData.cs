using AutoFixture;
using AutoFixture.Xunit2;

namespace RestaurantReservation.Test.Common;

public class CustomAutoData : AutoDataAttribute
{
    public CustomAutoData(int recursionDepth = 2) : base(() => FixtureFactory(recursionDepth))
    {
    }

    private static IFixture FixtureFactory(int recursionDepth)
    {
        var fixture = new Fixture();
        fixture.Behaviors.Add(new OmitOnRecursionBehavior(recursionDepth));
        return fixture;
    }
}