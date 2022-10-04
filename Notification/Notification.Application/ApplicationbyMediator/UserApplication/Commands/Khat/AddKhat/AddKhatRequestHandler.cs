using MediatR;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.Common.Events.KhatEvent;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.Common.Events.UserEvent;
using Notification.Application.Service.ReadRepository.User;
using Notification.Application.Service.User.Doc;
using Notification.Application.Service.WriteRepository.User.Kat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.UserApplication.Commands.Khat.AddKhat
{ 
    public class AddKhatRequestHandler : IRequestHandler<AddKhatRequest, AddKhatResponse>
    {
        private readonly IKhat _userKhat;
        private readonly ChannelQueue<UserEdited> _channel;

        private readonly ChannelQueue<KhatAdded> _channeladdkhat;

        private readonly ReadSMSUser _readSMSUser;

        public AddKhatRequestHandler(IKhat userKhat
            , ChannelQueue<UserEdited> channel
            , ReadSMSUser readSMSUser
            , ChannelQueue<KhatAdded> channeladdkhat
          )
        {
            _channel = channel;
            _userKhat = userKhat;
           _readSMSUser = readSMSUser;
            _channeladdkhat = channeladdkhat;
        }
        public async Task<AddKhatResponse> Handle(AddKhatRequest request, CancellationToken cancellationToken = default)
        {
            //in 1 DB
            var command = _userKhat.AddKhat(new KhatModel { DedlineKhat=request.DedlineKhat
            ,IdSarKhat=request.IdSarKhat,
            IdTransaction=request.IdTransaction,
            IdUser=request.IdUser,
            LineNumber=request.LineNumber,
            Statuse=request.Statuse,
            Type=request.Type});


            //  in 2 DB
            //1.  the first way:

           // var us = _readSMSUser.GetByUSerIdAsync(request.IdUser, cancellationToken);
         

            //new Domain.Entities.ReadModels.KhototUSer
            //{
            //    PathofSave = command,
            //    Confirmcheck = false,
            //    TypeofDoc = _userDoc.getDocTypebyId(request.idDocumentType)
            //});

            //await _channel.AddToChannelAsync(new UserEdited { user = us.Result }, cancellationToken);


            ////2.   the second way:
            await _channeladdkhat.AddToChannelAsync(new KhatAdded { Idkhat = command }, cancellationToken);


            //
            return new AddKhatResponse {  Idkhat= command };

        }
    }
}
