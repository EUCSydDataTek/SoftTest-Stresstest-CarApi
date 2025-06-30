namespace CarApi.Services.LoadEmulation.Middleware
{
    public class RequestDelayMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILEService _LeService;
        private readonly ILogger _logger;

        private int _timeout = 0;

        public RequestDelayMiddleware(ILEService leService,ILogger<RequestDelayMiddleware> logger,RequestDelegate next)
        {
            _next = next;
            _LeService = leService;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await CalculateDelayAsync();
            await Task.Delay(_timeout);
            await _next(context);
        }
        private Task CalculateDelayAsync()
        {
            var Steps = _LeService.Options.CalculateCurrentSteps(_LeService.GetBucketState());

            if (Steps > 75)
            {
                _timeout = 0;
            }            
            else if (Steps <= 75 && Steps > 65)
            {
                if (_timeout != 2000)
                {
                    _timeout = 2000;
                    LogDelay();
                }
            }
            else if (Steps <= 65 && Steps > 50)
            {
                if (_timeout != 4000)
                {
                    _timeout = 4000;
                    LogDelay();
                }
            }
            else if (Steps <= 50 && Steps > 25)
            {
                if (_timeout != 8000)
                {
                    _timeout = 8000;
                    LogDelay();
                }
            }
            else if (Steps <= 25 && Steps > 10)
            {
                if (_timeout != 10000)
                {
                    _timeout = 10000;
                    LogDelay();
                }
            }
            else
            {
                if (_timeout != 20000)
                {
                    _timeout = 20000;
                    LogDelay();
                }
            }
            

            return Task.CompletedTask;
        }

        private void LogDelay()
        {
            _logger.LogWarning($"Delay has been set to {_timeout}ms.");
        }

    }
}
