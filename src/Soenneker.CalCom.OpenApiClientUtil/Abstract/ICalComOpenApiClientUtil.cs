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
    /// <summary>
    /// Gets the cached Cal.com client for the current utility instance.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<CalComOpenApiClient> Get(CancellationToken cancellationToken = default);
}
