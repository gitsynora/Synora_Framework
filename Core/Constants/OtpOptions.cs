namespace UltraNet.Core.Constants
{
    public class OtpOptions
    {
        public List<string> Strategies { get; set; } = new();
        public int CodeLength { get; set; } = 6;
    }
}

