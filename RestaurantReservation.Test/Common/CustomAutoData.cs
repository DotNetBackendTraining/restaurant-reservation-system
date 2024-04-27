using AutoFixture;
using AutoFixture.Xunit2;

namespace RestaurantReservation.Test.Common;

public class CustomAutoData : AutoDataAttribute
{
    public CustomAutoData() : base(FixtureFactory)
    {
    }

    public CustomAutoData(int recursionDepth) : base(() => FixtureFactory(recursionDepth))
    {
    }

    private static IFixture FixtureFactory()
    {
        var fixture = new Fixture();
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        return fixture;
    }

    private static IFixture FixtureFactory(int recursionDepth)
    {
        var fixture = FixtureFactory();
        fixture.Behaviors.Add(new OmitOnRecursionBehavior(recursionDepth));
        return fixture;
    }
}