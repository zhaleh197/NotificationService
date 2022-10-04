using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.Common.Events.UserEvent;

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

                        var user = writeRepository.GetuserbyIduser(item.IdUSer, stoppingToken);
                        var typuser = writeRepository.Gettypeofuser(user.IdUSerType);

                        var doc = UserDoc.getDocpathbyIDUserList(user.IdUser);
                        var lkhototuser = writeRepository.GetKhototUser(user.IdUser);


                        SMSUser u = new SMSUser
                        {

                            IdUser = user.IdUser,

                            TitlePackage = "None",
                            TitleUsertype = writeRepository.Gettypeofuser(user.IdUSerType),
                            Phone = user.Phone,
                            CreditFinance = user.CreditFinance,
                            CridetMeaasage = user.CridetMeaasage,
                            Role = writeRepository.GetRoleofuser(user.IdRole),
                            //Khotot = khotot,
                            //PathDocs = docsuser,
                            ZaribTakhfif = user.PackageTariff.ZaridTakhfifPaciTareeffe

                        };
                        if (user != null)
                        {
                            await readRepository.AddAsync(u, stoppingToken);
                        }

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
                            var filtr = Builders<SMSUser>.Filter.Eq("Id", u.Id);
                            var update = Builders<SMSUser>.Update.Set("KhototUser", khotot); 
                            await readRepository.insercpinlmnAsyncfinal(filtr, update);
                        }

                        //edit user to docs
                        if (doc != null)
                        {
                            var docsuser = new List<Docclas>();
                            //if (doc != null) path = doc.path;
                            foreach (var d in doc)
                            {
                                docsuser.Add(new Docclas
                                {
                                    Confirmcheck = d.Confirmcheck,
                                    PathofSave = d.path,
                                    TypeofDoc = d.DocumentType
                                });
                            }

                            var filtr = Builders<SMSUser>.Filter.Eq("Id", u.Id);
                            var update = Builders<SMSUser>.Update.Set("DocUser", docsuser);
                            await readRepository.insercpinlmnAsyncfinal(filtr, update);
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
