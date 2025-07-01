

namespace CarApi.Services.LoadEmulation.Background
{
    public class LeHostService : BackgroundService
    {

        private readonly ILEService _LEService;

        public LeHostService(ILEService leService)
        {
            _LEService = leService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(_LEService.Options.RequestRefillRateMs));

            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                _LEService.AddTokens();

                if (stoppingToken.IsCancellationRequested)
                {
                    break;
                }
            }
        }
    }
}
