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
    public class AddDocWorker: BackgroundService
    { 
        private readonly ChannelQueue<DocAdded> _DocAddedlChannel;
        private readonly ILogger<AddDocWorker> _logger;
        private readonly IServiceProvider _serviceProvider;
        // private readonly IGetSMS _getSMS;
        // private readonly IPostSMS _postSMS;

        public AddDocWorker(ChannelQueue<DocAdded> DocAddedlChannel, ILogger<AddDocWorker> logger, IServiceProvider serviceProvider)//, IPostSMS postSMS)
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
                 var UserDoc = scope.ServiceProvider.GetRequiredService<IUserDoc>();

                var writeRepository = scope.ServiceProvider.GetRequiredService<ILocalUser>();

                var readRepository = scope.ServiceProvider.GetRequiredService<ReadSMSUser>();
                try
                {
                    await foreach (var item in _DocAddedlChannel.ReturnValue(stoppingToken))
                    {
                        var docc = UserDoc.getDocbyId(item.Iddoc);
                    
                        if (docc != null)
                        {
                            var user = writeRepository.GetuserbyIduser(docc.idUser, stoppingToken);
                            var doc = UserDoc.getDocpathbyIDUserList(user.IdUser);
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
            
        }
    }

} 
