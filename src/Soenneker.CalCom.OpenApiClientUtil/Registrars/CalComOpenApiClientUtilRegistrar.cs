using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.CalCom.HttpClients.Registrars;
using Soenneker.CalCom.OpenApiClientUtil.Abstract;

namespace Soenneker.CalCom.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class CalComOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="CalComOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddCalComOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddCalComOpenApiHttpClientAsSingleton()
                .TryAddSingleton<ICalComOpenApiClientUtil, CalComOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="CalComOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddCalComOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddCalComOpenApiHttpClientAsSingleton()
                .TryAddScoped<ICalComOpenApiClientUtil, CalComOpenApiClientUtil>();

        return services;
    }
}
