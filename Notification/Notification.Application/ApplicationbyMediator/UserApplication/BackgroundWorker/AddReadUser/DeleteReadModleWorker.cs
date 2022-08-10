using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.Common.Events;
using Notification.Application.Service.ReadRepository.User;
using Notification.Application.Service.User.Enroll;
using Notification.Domain.Entities.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.AddReadUser
{
    public class DeleteReadModleWorker : BackgroundService
    {
        private readonly ChannelQueue<UserDeleted> _readModelChannel;
        private readonly ILogger<DeleteReadModleWorker> _logger;
        private readonly IServiceProvider _serviceProvider;
        // private readonly IGetSMS _getSMS;
        // private readonly IPostSMS _postSMS;

        public DeleteReadModleWorker(ChannelQueue<UserDeleted> readModelChannel, ILogger<DeleteReadModleWorker> logger, IServiceProvider serviceProvider)//, IPostSMS postSMS)
        {
            _readModelChannel = readModelChannel;
            _logger = logger;
            _serviceProvider = serviceProvider;
            //  _postSMS = postSMS;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();

                var writeRepository = scope.ServiceProvider.GetRequiredService<ILocalUser>();
                var readRepository = scope.ServiceProvider.GetRequiredService<ReadSMSUser>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                       // var user = writeRepository.GetuserbyIduser(item.IdUSer, stoppingToken);

                      //  if (user != null)
                       // {
                            await readRepository.DeleteByUserIdAsync(item.IdUSer, stoppingToken);
                      //  }
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e, e.Message);
                }
            }
        }
    }
}

