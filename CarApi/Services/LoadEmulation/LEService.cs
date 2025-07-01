namespace CarApi.Services.LoadEmulation
{
    public class LEService : ILEService
    {

        private uint _BucketCounter = 0;

        private LoadEmulationOptions _Options;

        private readonly ILogger _logger;

        public LEService(LoadEmulationOptions options,ILogger<LEService> logger)
        {
            _Options = options;
            _BucketCounter = _Options.MaxRequests;
            _logger = logger;
        }

        public LoadEmulationOptions Options { get { return _Options; } }

        public uint GetBucketState()
        {
            return _BucketCounter;
        }

        public void UseToken()
        {
            if (_BucketCounter != 0)
            {
                _BucketCounter--;
            }
        }

        public void AddTokens(uint Amount)
        {
            uint AddedRequests = _BucketCounter + Amount;

            if (AddedRequests > _Options.MaxRequests)
            {
                _BucketCounter = _Options.MaxRequests;
            }
            else
            {
                _BucketCounter = AddedRequests;
            }
        }

        public void AddTokens()
        {
            uint AddedRequests = _BucketCounter + _Options.RequestRefillAmount;

            if (AddedRequests > _Options.MaxRequests)
            {
                if (_BucketCounter != _Options.MaxRequests)
                {
                    _BucketCounter = _Options.MaxRequests;
                    _logger.LogInformation("Bucket Reset.");
                }
            }
            else
            {
                _BucketCounter = AddedRequests;
                _logger.LogInformation($"Added tokens to bucket. Count: {_BucketCounter}");
            }
        }
    }
}
