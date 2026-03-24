using Soenneker.CalCom.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.CalCom.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class CalComOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly ICalComOpenApiClientUtil _openapiclientutil;

    public CalComOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<ICalComOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
