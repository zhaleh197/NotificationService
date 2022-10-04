using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.Common.Events.DocEvent;
using Notification.Application.Service.ReadRepository.User;
using Notification.Application.Service.User.Doc;
using Notification.Application.Service.User.Enroll;
using Notification.Domain.Entities.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.DocReadUser
{
    

    public class DeleteDocWorker : BackgroundService
    {
        private readonly ChannelQueue<DocD> _readModelChannel;
        private readonly ILogger<DeleteDocWorker> _logger;
        private readonly IServiceProvider _serviceProvider;
        // private readonly IGetSMS _getSMS;
        // private readonly IPostSMS _postSMS;

        public DeleteDocWorker(ChannelQueue<DocD> readModelChannel, ILogger<DeleteDocWorker> logger, IServiceProvider serviceProvider)//, IPostSMS postSMS)
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
                var UserDoc = scope.ServiceProvider.GetRequiredService<IUserDoc>();

                var writeRepository = scope.ServiceProvider.GetRequiredService<ILocalUser>();

                var readRepository = scope.ServiceProvider.GetRequiredService<ReadSMSUser>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var docc = UserDoc.getDocbyId(item.Id);

                        if (docc != null)
                        {
                            var user = writeRepository.GetuserbyIduser(docc.idUser, stoppingToken);
                            var doc = UserDoc.getDocpathbyIDUserList(user.Id);
                            //await readRepository.ADDDoc(
                            //    new Docclas
                            //    {
                            //        Confirmcheck = docc.Confirmcheck,
                            //        PathofSave = docc.path,
                            //        TypeofDoc = docc.DocumentType
                            //    }, stoppingToken);


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

                            var filtr = Builders<SMSUser>.Filter.Eq("IdUser", user.IdUser);
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


            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    using var scope = _serviceProvider.CreateScope();

            //   // var writeRepository = scope.ServiceProvider.GetRequiredService<ILocalUser>();
            //    var readRepository = scope.ServiceProvider.GetRequiredService<ReadUserDoc>();
            //    try
            //    {
            //        await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
            //        {
            //            // var user = writeRepository.GetuserbyIduser(item.IdUSer, stoppingToken);

            //            //  if (user != null)
            //            // {
            //            await readRepository.DeleteByDocIdAsync(item.Id, stoppingToken);
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
