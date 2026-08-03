namespace CarApi.Services.FakeLoad
{
    public static class FakeLoadExtensions
    {
        public static IApplicationBuilder UseFakeLoad(this IApplicationBuilder builder)
        {
            return builder.Use(async (context, next) =>
            {
                var scope = context.RequestServices.CreateScope();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<FakeLoadMiddleWare>>();

                // Instantiate and run our custom middleware logic
                var middleware = new FakeLoadMiddleWare(next, logger);
                await middleware.InvokeAsync(context);
            });
        }

    }
}
