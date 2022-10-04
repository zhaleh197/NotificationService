using MediatR;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.Common.Events;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.Common.Events.DocEvent;
using Notification.Application.Service.ReadRepository.User;
using Notification.Application.Service.User.Doc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.UserApplication.Commands.Doc.DeleteDoc
{

    public class DeleteDocRequestHandler : IRequestHandler<DeleteDocRequest, DeleteKhatResponse>
    {
        private readonly IUserDoc _userDoc;
        // private readonly ChannelQueue<UserDeleted> _channel;

        private readonly ReadSMSUser _readSMSUser;
        private readonly ChannelQueue<DocD> _channel;
        public DeleteDocRequestHandler(IUserDoc userDoc
           // , ChannelQueue<UserDeleted> channel
            ,ChannelQueue<DocD> channel
            , ReadSMSUser readSMSUser

            )
        {
            _channel = channel;
            _userDoc = userDoc;
            _readSMSUser = readSMSUser;
        }
        public async Task<DeleteKhatResponse> Handle(DeleteDocRequest request, CancellationToken cancellationToken = default)
        {
            //in 1
            var command = _userDoc.DeletDoc(request.idDoc);

            //in 2
            await _channel.AddToChannelAsync(new DocD { Id= request.idDoc }, cancellationToken);

             return new DeleteKhatResponse { idDoc = request.idDoc };

        }
    }

}
