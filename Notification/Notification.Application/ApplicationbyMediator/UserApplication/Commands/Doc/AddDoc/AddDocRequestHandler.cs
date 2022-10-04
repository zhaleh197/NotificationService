using MediatR;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.Common.Events.DocEvent;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.Common.Events.UserEvent;
using Notification.Application.Service.ReadRepository.User;
//using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
//using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.Common.Events;
using Notification.Application.Service.User.Doc;
using Notification.Application.Service.User.Enroll;
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
      //  private readonly ChannelQueue<UserEdited> _channel;

        private readonly ChannelQueue<DocAdded> _channeladddoc;
        
        private readonly ReadSMSUser _readSMSUser;

        public AddDocRequestHandler( IUserDoc userDoc
          //  , ChannelQueue<UserEdited> channel
            , ReadSMSUser readSMSUser 
            , ChannelQueue<DocAdded> channeladddoc
          )
        {
           // _channel = channel;
            _userDoc = userDoc;
            _readSMSUser = readSMSUser;
            _channeladddoc = channeladddoc;
        }
        public async Task<AddDocResponse> Handle(AddDocRequest request, CancellationToken cancellationToken = default)
        {
            //in 1 DB
            var command = _userDoc.SendDoc(
                new DocModel
                {
                    base64imagopDoc = request.base64imagopDoc ,
                    Confirmcheck=request.Confirmcheck,
                    idDocumentType=request.idDocumentType,
                    idUser=request.idUser
                }
                );


            ////in 2 DB
            //// //1.  the first way:

            //var us = _readSMSUser.GetByUSerIdAsync(request.idUser, cancellationToken);
            //us.Result.PathDocs.Add(
            //    new Domain.Entities.ReadModels.Docclas
            //    {
            //        PathofSave = command,
            //        Confirmcheck = false,
            //        TypeofDoc = _userDoc.getDocTypebyId(request.idDocumentType)
            //    });

            //await _channel.AddToChannelAsync(new UserEdited { user = us.Result }, cancellationToken);


            ////2.   the second way:
            await _channeladddoc.AddToChannelAsync(
            new DocAdded
            { Iddoc=command },
            cancellationToken
            );

            //
            //return new AddDocResponse {  addresDoc=command };
            return new AddDocResponse { Iddoc = command };
        }
    }
}
