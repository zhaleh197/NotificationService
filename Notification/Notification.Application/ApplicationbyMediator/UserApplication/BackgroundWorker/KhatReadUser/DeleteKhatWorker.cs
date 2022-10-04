using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.Common.Events.KhatEvent;
using Notification.Application.Service.ReadRepository.User;
using Notification.Application.Service.User.Enroll;
using Notification.Application.Service.WriteRepository.User.Kat;
using Notification.Application.Service.WriteRepository.User.Kat.SarKhat;
using Notification.Domain.Entities.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.KhatReadUser
{
    public class DeleteKhatWorker : BackgroundService
    {

        private readonly ChannelQueue<KhatD> _readModelChannel;
        private readonly ILogger<DeleteKhatWorker> _logger;
        private readonly IServiceProvider _serviceProvider;
        // private readonly IGetSMS _getSMS;
        // private readonly IPostSMS _postSMS;

        public DeleteKhatWorker(ChannelQueue<KhatD> readModelChannel, ILogger<DeleteKhatWorker> logger, IServiceProvider serviceProvider)//, IPostSMS postSMS)
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
                var Khat = scope.ServiceProvider.GetRequiredService<IKhat>();
                var writeRepository = scope.ServiceProvider.GetRequiredService<ILocalUser>();

                var SarKhat = scope.ServiceProvider.GetRequiredService<ISarKhat>();
                var readRepository = scope.ServiceProvider.GetRequiredService<ReadSMSUser>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var khat = Khat.GetKhatbyId(item.Id);
                        var sarkhat = SarKhat.GetSarKhatbyId(khat.IdSarKhat);
                        if (khat != null)
                        {
                            //var KhototUSer = new KhototUSer
                            //{
                            //    DedlineKhat = khat.DedlineKhat,
                            //    KhatNumber = khat.LineNumber,
                            //    Statuse = khat.Statuse,
                            //    Type = khat.Type,
                            //    SarKhat = new sarkhat
                            //    {
                            //        BasePrice = sarkhat.BasePrice,
                            //        EnglishZarib = sarkhat.EnglishZarib,
                            //        HamrahAvalZarib = sarkhat.HamrahAvalZarib,
                            //        IranselZarib = sarkhat.IranselZarib,
                            //        PersianZarib = sarkhat.PersianZarib,
                            //        RaytelZarib = sarkhat.RaytelZarib,
                            //        SarKhatNumber = sarkhat.SarKhatNumber,
                            //        Spacial = sarkhat.Spacial,
                            //        TejasriLinkZarib = sarkhat.TejasriLinkZarib
                            //    }
                            //};

                            var user = writeRepository.GetuserbyIduser(khat.IdUser, stoppingToken);
                            var typuser = writeRepository.Gettypeofuser(user.IdUSerType);

                            var lkhototuser = writeRepository.GetKhototUser(user.Id);

                            //edit user to khotot
                            if (lkhototuser != null)
                            {
                                List<KhototUSer> khotot = new List<KhototUSer>();
                                foreach (var k in lkhototuser)
                                {

                                    khotot.Add(new KhototUSer
                                    {
                                        DedlineKhat = k.DedlineKhat,
                                        KhatNumber = k.KhatNumber,
                                        Statuse = k.Statuse,
                                        Type = k.Type,
                                        SarKhat = new sarkhat
                                        {
                                            BasePrice = k.SarKhat.BasePrice,
                                            EnglishZarib = k.SarKhat.EnglishZarib,
                                            HamrahAvalZarib = k.SarKhat.HamrahAvalZarib,
                                            IranselZarib = k.SarKhat.IranselZarib,
                                            PersianZarib = k.SarKhat.PersianZarib,
                                            RaytelZarib = k.SarKhat.RaytelZarib,
                                            SarKhatNumber = k.SarKhat.SarKhatNumber,
                                            Spacial = k.SarKhat.Spacial,
                                            TejasriLinkZarib = k.SarKhat.TejasriLinkZarib
                                        }
                                    });
                                }

                                var filtr = Builders<SMSUser>.Filter.Eq("IdUser", user.IdUser);
                                var update = Builders<SMSUser>.Update.Set("KhototUser", khotot);
                                await readRepository.insercpinlmnAsyncfinal(filtr, update);

                                // await readRepository.EditrecordAsync(u, filtr, stoppingToken);
                                //await readRepository.ADDKhat(KhototUSer , stoppingToken);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e, e.Message);
                }
            }
            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    using var scope = _serviceProvider.CreateScope();

            //    // var writeRepository = scope.ServiceProvider.GetRequiredService<ILocalUser>();
            //    var readRepository = scope.ServiceProvider.GetRequiredService<ReadUserKhat>();
            //    try
            //    {
            //        await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
            //        {
            //            // var user = writeRepository.GetuserbyIduser(item.IdUSer, stoppingToken);

            //            //  if (user != null)
            //            // {
            //            await readRepository.DeleteByKhatIdAsync(item.Id, stoppingToken);
            //            //  }
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        _logger.LogError(e, e.Message);
            //    }
            //}

        }
    }
}
