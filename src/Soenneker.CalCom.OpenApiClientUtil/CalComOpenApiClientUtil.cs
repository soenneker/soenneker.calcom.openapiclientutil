using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.CalCom.HttpClients.Abstract;
using Soenneker.CalCom.OpenApiClientUtil.Abstract;
using Soenneker.CalCom.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.CalCom.OpenApiClientUtil;

///<inheritdoc cref="ICalComOpenApiClientUtil"/>
public sealed class CalComOpenApiClientUtil : ICalComOpenApiClientUtil
{
    private readonly AsyncSingleton<CalComOpenApiClient> _client;

    public CalComOpenApiClientUtil(ICalComOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<CalComOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("CalCom:ApiKey");
            string authHeaderValueTemplate = configuration["CalCom:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

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
