using AuthApi.Services;
using AuthApi.Services.Interfaces;

namespace AuthApi.Configurations;

public static class ServicesConfigurations
{
    public static IServiceCollection AddServiceConfigurations(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}