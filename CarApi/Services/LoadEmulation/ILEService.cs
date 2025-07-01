namespace CarApi.Services.LoadEmulation
{
    public interface ILEService
    {
        uint GetBucketState();
        public LoadEmulationOptions Options { get; }
        void UseToken();
        void AddTokens(uint Amount);
        void AddTokens();
    }
}