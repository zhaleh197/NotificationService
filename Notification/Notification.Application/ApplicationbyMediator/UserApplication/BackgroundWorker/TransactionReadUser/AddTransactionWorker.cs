using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.Common.Events.TransactionEvent;
using Notification.Application.Service.ReadRepository.User;
using Notification.Application.Service.User.Doc;
using Notification.Application.Service.User.Enroll;
using Notification.Application.Service.WriteRepository.User.Transaction;
using Notification.Domain.Entities.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.TransactionReadUser
{

    public class AddTransactionWorker : BackgroundService
    {
        private readonly ChannelQueue<TransactionAdd> _DocAddedlChannel;
        private readonly ILogger<AddTransactionWorker> _logger;
        private readonly IServiceProvider _serviceProvider;
        // private readonly IGetSMS _getSMS;
        // private readonly IPostSMS _postSMS;

        public AddTransactionWorker(ChannelQueue<TransactionAdd> DocAddedlChannel, ILogger<AddTransactionWorker> logger, IServiceProvider serviceProvider)//, IPostSMS postSMS)
        {
            _DocAddedlChannel = DocAddedlChannel;
            _logger = logger;
            _serviceProvider = serviceProvider;
            //  _postSMS = postSMS;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();
                var UserTransaction = scope.ServiceProvider.GetRequiredService<ITransactionss>();

                var writeRepository = scope.ServiceProvider.GetRequiredService<ILocalUser>();

                var readRepository = scope.ServiceProvider.GetRequiredService<ReadSMSUser>();
                try
                {
                    await foreach (var item in _DocAddedlChannel.ReturnValue(stoppingToken))
                    {
                        var olduser = readRepository.GetByUSerIdAsync(item.IdTrans, stoppingToken);
                        var user = writeRepository.GetuserbyIduser(item.IdTrans, stoppingToken);

                        //    var filtr = Builders<SMSUser>.Filter.Eq("IdUser", user.IdUser);
                        //    var update = Builders<SMSUser>.Update.Set("CreditFinance",user.CreditFinance );
                        //update.AddToSet("CridetMeaasage", user.CridetMeaasage);
                        //update.AddToSet("TitlePackage", user.PackageTariff.TitlePackage);
                        //update.AddToSet("ZaribTakhfif", user.PackageTariff.ZaridTakhfifPaciTareeffe);
                        //await readRepository.EditrecordAsync(update, filtr, stoppingToken);

                        SMSUser newuser = new SMSUser {
                            CreditFinance=user.CreditFinance 
                        ,TitlePackage= user.PackageTariff.TitlePackage,
                        CridetMeaasage=user.CridetMeaasage,
                        DocUser= olduser.Result.DocUser,
                        IdUser=user.IdUser,
                        KhototUser=olduser.Result.KhototUser,
                        Phone=olduser.Result.Phone,
                        Role=olduser.Result.Role,
                        TitleUsertype=olduser.Result.TitleUsertype,
                        ZaribTakhfif= user.PackageTariff.ZaridTakhfifPaciTareeffe
                        };
                        await readRepository.EditUser(newuser, user.IdUser, stoppingToken);
                 
                           


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
