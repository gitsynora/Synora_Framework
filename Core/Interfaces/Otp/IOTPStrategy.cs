namespace UltraNet.Core.Interfaces.Otp
{
    public interface IOTPStrategy
    {
        string Key { get; }
        Task SendAsync(string receiver, string code);
    }
}
