using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.CalCom.HttpClients.Abstract;
using Soenneker.CalCom.OpenApiClientUtil.Abstract;
using Soenneker.CalCom.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.CalCom.OpenApiClientUtil;

public sealed class CalComOpenApiClientUtil : ICalComOpenApiClientUtil
{
    private readonly AsyncSingleton<CalComOpenApiClient> _client;

    public CalComOpenApiClientUtil(ICalComOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<CalComOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new CalComOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<CalComOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
