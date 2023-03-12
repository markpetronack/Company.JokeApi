using Microsoft.Extensions.Options;

namespace Company.JokeApi.Extensions;

public static class OptionsExtensions
{
    public static void AddConfigOptions<T>(this IServiceCollection services, string configSectionPath) where T : class
    {
        services.AddOptions<T>()
            .BindConfiguration(configSectionPath)
            .ValidateDataAnnotations()
            .ValidateOnStart();
        services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<T>>().Value);
    }
}

