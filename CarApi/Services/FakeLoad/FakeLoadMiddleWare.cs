using System.Security.Cryptography;

namespace CarApi.Services.FakeLoad
{
    public class FakeLoadMiddleWare
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<FakeLoadMiddleWare> _logger;
        int seed = 0;

        public FakeLoadMiddleWare(RequestDelegate next, ILogger<FakeLoadMiddleWare> logger)
        {
            seed = Random.Shared.Next(1, 10000);
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (File.Exists("DoNotDelete.txt"))
            {
                // Normal Requests
                await _next.Invoke(context);
                return;
            }
            else
            {
                Random rnd = new Random(seed);

                if (context.Request.Path.Value?.ToLower().Contains("scalar") ?? false)
                {
                    await _next.Invoke(context);
                    return;
                }

                switch (rnd.Next(1,15))
                {
                    case 1:
                        context.Response.StatusCode = 500;
                        break;
                    case 2:
                        context.Response.StatusCode = 405;
                        break;
                    case 3:
                        context.Response.StatusCode = 405;
                        break;
                    case 4:
                        context.Response.StatusCode = 420;
                        break;
                    case 5:
                        context.Response.StatusCode = 420;
                        break;
                    case 6:
                        context.Response.StatusCode = 418;
                        break;
                    case 7:
                        context.Response.StatusCode = 400;
                        break;
                    default:
                        await _next.Invoke(context);
                        break;
                }

                return;

            }
        }
    }
}
