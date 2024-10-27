using AuthApi.Services;
using AuthApi.Services.Interfaces;

namespace AuthApi.Configurations;

public static class ServicesConfigurations
{
    public static IServiceCollection AddServiceConfigurations(this IServiceCollection services)
    {
        services.AddSingleton<IAuthService, AuthService>();
        return services;
    }
}