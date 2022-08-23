using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.Common.Events;

using Notification.Application.Service.ReadRepository.User;
//using Notification.Application.Service.SMS.Queris.Get;
using Notification.Application.Service.SMS.Queris.Post;
using Notification.Application.Service.User.Doc;
using Notification.Application.Service.User.Enroll;
using Notification.Domain.Entities.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.AddReadUser
{
    public class AddReadModelWorker : BackgroundService
    {
        private readonly ChannelQueue<UserAdded> _readModelChannel;
        private readonly ILogger<AddReadModelWorker> _logger;
        private readonly IServiceProvider _serviceProvider;
        // private readonly IGetSMS _getSMS;
        // private readonly IPostSMS _postSMS;

        public AddReadModelWorker(ChannelQueue<UserAdded> readModelChannel, ILogger<AddReadModelWorker> logger, IServiceProvider serviceProvider)//, IPostSMS postSMS)
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
                var UserDoc = scope.ServiceProvider.GetRequiredService<IUserDoc>();
                var readRepository = scope.ServiceProvider.GetRequiredService<ReadSMSUser>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        string path = "";
                        var user =  writeRepository.GetuserbyIduser(item.IdUSer, stoppingToken);
                        var doc = UserDoc.getDocpathbyIDUser(user.Id);
                        if (doc != null) path = doc.path;
                        if (user != null)
                        {
                            await readRepository.AddAsync(new SMSUser
                            {
                                DeadlinePackage = user.DeadlinePackage,
                                EnglishTariff=user.PackageTariff.EnglishTariff,
                                FarsiTariff=user.PackageTariff.FarsiTariff,
                                IdUser=user.IdUser,
                                PricePackage=user.PackageTariff.PackageSMS.PricePackage,
                                SarKhatNumber="100",
                                Spacial=false,
                                TitlePackage=user.PackageTariff.PackageSMS.TitlePackage,
                                TitleUsertype=user.USerType.Title,
                                Phone=user.Phone,
                                PathDocs=path,

                            }, stoppingToken);
                        }
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
