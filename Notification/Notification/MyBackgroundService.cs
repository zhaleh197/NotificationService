namespace NotificationAPI
{
    public class MyBackgroundService : BackgroundService
    {
        private readonly ILogger<MyBackgroundService> _logger;
        public MyBackgroundService(ILogger<MyBackgroundService> logger)
        {
            _logger=logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           
            while (!stoppingToken.IsCancellationRequested)
            {
          _logger.LogInformation("background service test: executeasync {dateTime}",DateTime.Now);

                await Task.Delay(TimeSpan.FromSeconds(1),stoppingToken);
            }
            //Console.WriteLine("background service test");
            //return Task.CompletedTask;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("background service test STOP : stopAsync {dateTime}", DateTime.Now);
            return base.StartAsync(cancellationToken);
        }
    }
}
