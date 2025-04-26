using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UltraNet.Core.Constants;
using UltraNet.Core.Interfaces.Otp;
using UltraNet.Modules.Otp;
using UltraNet.Modules.Otp.Strategies;


namespace UltraNet.Core.Extensions;

public static class OtpServiceCollectionExtensions
{
    public static IServiceCollection AddUltraOtp(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<OtpOptions>(configuration.GetSection("OtpOptions"));

        services.AddScoped<IOTPStrategy, SmsOtpStrategy>();
        services.AddScoped<IOTPStrategy, EmailOtpStrategy>();
        services.AddScoped<IOTPService, OtpService>();

        return services;
    }
}
