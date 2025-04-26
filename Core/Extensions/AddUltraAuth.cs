using Microsoft.Extensions.DependencyInjection;
using UltraNet.Core.Interfaces.JWT;
using UltraNet.Core.Interfaces.PasswordHasher;
using UltraNet.Modules.Auth;

namespace UltraNet.Core.Extensions;
public static class AuthServiceCollectionExtensions
{
    public static IServiceCollection AddUltraAuth(this IServiceCollection services)
    {
        services.AddScoped<ITokenGenerator, TokenGenerator>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
