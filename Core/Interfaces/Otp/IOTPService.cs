namespace UltraNet.Core.Interfaces.Otp
{
    public interface IOTPService
    {
        Task<string> GenerateAndSendOtpAsync(string receiver, int? length = null);
    }
}
