namespace UltraNet.Core.Interfaces.Caching
{
    public interface ICacheProviderFactory
    {
        ICacheProvider GetProvider(string name);
    }
}
