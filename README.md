[![](https://img.shields.io/nuget/v/soenneker.calcom.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.calcom.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.calcom.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.calcom.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.calcom.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.calcom.openapiclientutil/actions/workflows/codeql.yml)
[![](https://img.shields.io/nuget/dt/soenneker.calcom.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.calcom.openapiclientutil/)

# Soenneker.CalCom.OpenApiClientUtil

Provides a lazily created Cal.com Kiota client backed by the configured cached `HttpClient`.

## Installation

```bash
dotnet add package Soenneker.CalCom.OpenApiClientUtil
```

## Configuration

```json
{
  "CalCom": {
    "ApiKey": "your-api-key"
  }
}
```

`CalCom:ApiKey` is required. The underlying HTTP provider adds it as Cal.com's required `apiKey` query parameter. `CalCom:ClientBaseUrl` can override the default API base URL for a compatible proxy or test server.

## Registration and usage

```csharp
using Soenneker.CalCom.OpenApiClient;
using Soenneker.CalCom.OpenApiClientUtil.Abstract;
using Soenneker.CalCom.OpenApiClientUtil.Registrars;

services.AddCalComOpenApiClientUtilAsScoped();

public sealed class CalComService(ICalComOpenApiClientUtil clientUtil)
{
    public async Task<Stream?> GetUsers(CancellationToken cancellationToken)
    {
        CalComOpenApiClient client = await clientUtil.Get(cancellationToken);
        return await client.Users.GetAsync(cancellationToken: cancellationToken);
    }
}
```

Scoped registration is useful when the lightweight utility should be released with the consuming scope while its registered singleton HTTP provider remains available. Singleton registration is also available when one utility instance should be shared application-wide.

Generated operations may return `Stream` when the source OpenAPI document does not define a response schema. Dispose returned streams after reading them.
