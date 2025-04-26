using Microsoft.Extensions.Options;
using UltraNet.Core.Constants;
using UltraNet.Core.Helpers;
using UltraNet.Core.Interfaces.Otp;

namespace UltraNet.Modules.Otp
{
    public class OtpService : IOTPService
    {
        private readonly List<IOTPStrategy> _strategies;
        private readonly OtpOptions _options;

        public OtpService(IEnumerable<IOTPStrategy> strategies, IOptions<OtpOptions> options)
        {
            _strategies = strategies.ToList();
            _options = options.Value;
        }

        public async Task<string> GenerateAndSendOtpAsync(string receiver, int? length = null)
        {
            var code = OtpCodeGenerator.GenerateNumericCode(length ?? _options.CodeLength);

            var selected = _strategies
                .Where(s => _options.Strategies.Contains(s.Key, StringComparer.OrdinalIgnoreCase))
                .ToList();

            if (!selected.Any())
            {
                Console.WriteLine("Strategy not found!");
                return code;
            }

            foreach (var strategy in selected)
            {
                try
                {
                    await strategy.SendAsync(receiver, code);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error {strategy.Key}: {ex.Message}");
                }
            }

            return code;
        }
    }
}
