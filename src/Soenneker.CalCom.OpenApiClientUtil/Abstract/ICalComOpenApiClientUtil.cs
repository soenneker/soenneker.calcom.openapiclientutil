using Soenneker.CalCom.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.CalCom.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface ICalComOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<CalComOpenApiClient> Get(CancellationToken cancellationToken = default);
}
