using Notification.Application.Interface.Context;
using Notification.Application.Service.Common;
using Notification.Application.Service.SMS.background;
using Notification.Application.Service.SMS.Commands;
using Notification.Application.Service.SMS.Queris.Get;

namespace ServerGRPCNotification.Services
{
    internal class MyBackgroundService : BackgroundService
    {
        private readonly ILogger<MyBackgroundService> _logger;
        private readonly IExecuteBackground _executeBackground;
        
        // private readonly ISMSService _sMSService;
        //private readonly ITaskJob<ResultGetQeueUserSMS> _taskJob;
        private readonly ITaskJobs _taskJob;
        public MyBackgroundService(ILogger<MyBackgroundService> logger,
            IExecuteBackground executeBackground,
            // ISMSService sMSService,
            //ITaskJob<ResultGetQeueUserSMS> taskJob,
            ITaskJobs taskJob
            )
        {
             _executeBackground= executeBackground;
            _logger = logger;
            //_sMSService = sMSService;
            _taskJob = taskJob;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("background Start");
                if (_taskJob.Qeuetask != null)
                {
                    _logger.LogInformation("Strart sending SMS since : {dateTime}", DateTime.Now);
                    if (_taskJob.Qeuetask.Any())
                    {
                        var request = _taskJob.Qeuetask.Dequeue();
                        _logger.LogInformation(" SMS send for {Resiver} in : {DateTime}", request.Resiver, DateTime.Now);
                            /////////////////////////////////////

                            //1.//_sMSService.SMSF(new SMSSendRequest2 { to = request.Resiver, txt = request.Body });
                            //2.//edit status in sms table to Sended.
                            //3.//delet in Qeuesms  table 

                          //  _executeBackground.Execute(new SMSSendRequest2 { to = request.Resiver, txt = request.Body });
                        /////////////////////////////////
                    }
                
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
                _logger.LogInformation(" Sending SMS is Finished at: {dateTime}", DateTime.Now);   }
                //Console.WriteLine("background service test");
                //return Task.CompletedTask;
            }
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("background service test STOP : stopAsync {dateTime}", DateTime.Now);
            return base.StopAsync(cancellationToken);
        }
    }
}
