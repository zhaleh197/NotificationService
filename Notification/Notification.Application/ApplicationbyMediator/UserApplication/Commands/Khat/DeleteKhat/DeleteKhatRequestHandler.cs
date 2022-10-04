using MediatR;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.Common.Events.KhatEvent;
using Notification.Application.Service.WriteRepository.User.Kat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.UserApplication.Commands.Khat.DeleteKhat
{
    public class DeleteKhatRequestHandler: IRequestHandler<DeletKhatRequest, DeleteKhatResponse>
    {
        private readonly IKhat _userKhat; 
         
        private readonly ChannelQueue<KhatD> _channel;
        public DeleteKhatRequestHandler(  
              ChannelQueue<KhatD> channel
            , IKhat userKhat

            )
        {
            _channel = channel;
            _userKhat = userKhat;
        }
        public async Task<DeleteKhatResponse> Handle(DeletKhatRequest request, CancellationToken cancellationToken = default)
        {
            //in 1
            var command = _userKhat.DeletKhat(request.idkhat);

            //in 2
            await _channel.AddToChannelAsync(new KhatD { Id = request.idkhat }, cancellationToken);

            return new DeleteKhatResponse { idkhat  = request.idkhat };

        }
    }

}
