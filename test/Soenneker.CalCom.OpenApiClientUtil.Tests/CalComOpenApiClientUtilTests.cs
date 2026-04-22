using Soenneker.CalCom.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.CalCom.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class CalComOpenApiClientUtilTests : HostedUnitTest
{
    private readonly ICalComOpenApiClientUtil _openapiclientutil;

    public CalComOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<ICalComOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
