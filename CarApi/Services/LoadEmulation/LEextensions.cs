using CarApi.Services.LoadEmulation.Background;
using CarApi.Services.LoadEmulation.Middleware;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace CarApi.Services.LoadEmulation
{
    public static class LEextensions
    {

        public static WebApplicationBuilder AddLoadEmulartion(this WebApplicationBuilder builder, Action<LoadEmulationOptions> optionsetter = null!)
        {
            LoadEmulationOptions options = new();

            if (optionsetter != null)
            {
                optionsetter.Invoke(options);
            }

            builder.Services.AddSingleton<ILEService, LEService>(s => new LEService(options, s.GetRequiredService<ILogger<LEService>>()));

            if (options.Enable)
            {
                builder.Services.AddHostedService<LeHostService>();
            }

            return builder;
        }

        public static WebApplicationBuilder AddLoadEmulartion(this WebApplicationBuilder builder, LoadEmulationOptions options)
        {
            if (options != null)
            {
                options = new();
            }

            builder.Services.AddSingleton<ILEService, LEService>(s => new LEService(options, s.GetRequiredService<ILogger<LEService>>()));

            if (options?.Enable ?? false)
            {
                builder.Services.AddHostedService<LeHostService>();
            }

            return builder;
        }

        public static WebApplication UseLoadEmulationBucket(this WebApplication app)
        {
            var ile = app.Services.GetRequiredService<ILEService>();

            if (ile.Options.Enable)
            {
                app.UseMiddleware<LeBucketMiddleware>();
            }

            return app;
        }

        public static WebApplication UseLoadEmulationDelay(this WebApplication app)
        {
            var ile = app.Services.GetRequiredService<ILEService>();

            if (ile.Options.Enable)
            {
                app.UseMiddleware<RequestDelayMiddleware>();
            }

            return app;
        }

        public static WebApplication UseLoadEmulationErrors(this WebApplication app)
        {
            var ile = app.Services.GetRequiredService<ILEService>();

            if (ile.Options.Enable)
            {
                app.UseMiddleware<RequestErrorMiddleware>();
            }

            return app;
        }
    }
}
