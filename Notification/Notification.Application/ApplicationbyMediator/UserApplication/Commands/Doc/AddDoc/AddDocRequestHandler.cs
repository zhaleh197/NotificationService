using MediatR;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.Common.Events;
using Notification.Application.Service.ReadRepository.User;
//using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
//using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.Common.Events;
using Notification.Application.Service.User.Doc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.UserApplication.Commands.Doc.AddDoc
{
    public class AddDocRequestHandler : IRequestHandler<AddDocRequest, AddDocResponse>
    {
        private readonly IUserDoc _userDoc;
        private readonly ChannelQueue<UserEdited> _channel;
        private readonly ReadSMSUser _readSMSUser;

        public AddDocRequestHandler( IUserDoc userDoc
            , ChannelQueue<UserEdited> channel
            , ReadSMSUser readSMSUser
          )
        {
            _channel = channel;
            _userDoc = userDoc;
            _readSMSUser = readSMSUser;
        }
        public async Task<AddDocResponse> Handle(AddDocRequest request, CancellationToken cancellationToken = default)
        {
            var command = _userDoc.SendDoc(new DocModel { base64imagopDoc = request.base64imagopDoc , Confirmcheck=request.Confirmcheck,idDocumentType=request.idDocumentType,idUser=request.idUser});

            var us = _readSMSUser.GetByUSerIdAsync(request.idUser,cancellationToken);
            us.Result.PathDocs = command;
            await _channel.AddToChannelAsync(new UserEdited { user=us.Result }, cancellationToken);
            // return await Task.FromResult(new EnrollUserResponse { Id= request.IdUser  });
            return new AddDocResponse {  addresDoc=command };

        }
    }
}
