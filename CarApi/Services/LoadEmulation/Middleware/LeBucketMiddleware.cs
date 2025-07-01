namespace CarApi.Services.LoadEmulation.Middleware
{
    public class LeBucketMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILEService _LeService;

        public LeBucketMiddleware(ILEService leService,RequestDelegate next) 
        {
            _next = next;
            _LeService = leService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _LeService.UseToken();
            await _next.Invoke(context);
        }

    }
}
