namespace UltraNet.Core.Interfaces.RateLimiting;
    public interface IRateLimiter
    {
        Task<bool> IsRequestAllowedAsync(string key);
    }


