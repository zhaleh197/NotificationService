using MediatR;
using Notification.Application.Service.User.Doc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.UserApplication.Commands.Doc.DeleteDoc
{

    public class DeleteDocRequestHandler : IRequestHandler<DeleteDocRequest, DeleteDocResponse>
    {
        private readonly IUserDoc _userDoc;//private readonly ChannelQueue<UserDeleted> _channel;
        public DeleteDocRequestHandler(IUserDoc userDoc
            //, ChannelQueue<UserDeleted> channel
            )
        {
            //_channel = channel;
            _userDoc = userDoc;
        }
        public async Task<DeleteDocResponse> Handle(DeleteDocRequest request, CancellationToken cancellationToken = default)
        {
            var command = _userDoc.DeletDoc(request.idDoc); 

            //await _channel.AddToChannelAsync(new UserDeleted { IdUSer = request.IdUser }, cancellationToken);
            return new DeleteDocResponse { idDoc = request.idDoc };

        }
    }

}
