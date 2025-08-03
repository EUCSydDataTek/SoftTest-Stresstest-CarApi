using System.Security.Cryptography;

namespace CarApi.Services.LoadEmulation.Middleware
{
    public class RequestErrorMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILEService _LeService;
        private readonly ILogger _logger;
        private Random _random;

        public RequestErrorMiddleware(ILEService leService, ILogger<RequestDelayMiddleware> logger, RequestDelegate next)
        {
            _next = next;
            _LeService = leService;
            _logger = logger;
            _random = new Random(Random.Shared.Next());
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var Steps = _LeService.Options.CalculateCurrentSteps(_LeService.GetBucketState());

            if (Steps >= 50 && Steps <= 90)
            {
                int res = _random.Next(0, 2);
                
                if (res == 1)
                {
                    RandomErrorGenerator eg = new(_random.Next());

                    int errorcode = eg.GenerateRandomErrorCode();

                    context.Response.StatusCode = errorcode;
                    _logger.LogInformation($"Returned Errorcode {errorcode} with step {Steps}");
                }
                else
                {
                    await _next.Invoke(context);
                }
            }
            else if (Steps >= 91)
            {
                RandomErrorGenerator eg = new(_random.Next());

                int errorcode = eg.GenerateRandomErrorCode();

                context.Response.StatusCode = errorcode;
                _logger.LogInformation($"Returned Errorcode {errorcode} with step {Steps}");
            }
            else 
            {
               await _next.Invoke(context);
            }

        }
    }
}
