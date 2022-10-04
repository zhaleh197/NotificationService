using MediatR;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.Common.Events.TransactionEvent;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.Common.Events.UserEvent;
using Notification.Application.Service.ReadRepository.User;
using Notification.Application.Service.User.Enroll;
using Notification.Application.Service.WriteRepository.User.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.UserApplication.Commands.Transaction.AddTrans
{
    public class AddTransactionHandler : IRequestHandler<AddTransactionRequest, AddTransactionResponse>
    {
        private readonly ITransactionss _userTransactin;
        private readonly ILocalUser _localUser;
        private readonly ChannelQueue<UserEdited> _channel;

        private readonly ChannelQueue<TransactionAdd> _channeladdkhat;

        private readonly ReadSMSUser _readSMSUser;

        public AddTransactionHandler(ITransactionss userTransactin
            , ILocalUser localUser
            , ChannelQueue<UserEdited> channel
            , ReadSMSUser readSMSUser
            , ChannelQueue<TransactionAdd> channeladdkhat
          )
        {
            _channel = channel;
            _userTransactin = userTransactin;
            _readSMSUser = readSMSUser;
            _channeladdkhat = channeladdkhat;
            _localUser = localUser;
        }
        public async Task<AddTransactionResponse> Handle(AddTransactionRequest request, CancellationToken cancellationToken = default)
        {

            var user = _localUser.GetuserbyIduser(request.IdUser);


            //in 1 DB
            //Transaction = 3 work.
            //1. add in transaction .

            var command = _userTransactin.AddTransaction(new TransactionModel
            {
                IdUser = request.IdUser,
                CodeRahgiriPardakht=request.CodeRahgiriPardakht,
                Discription=request.Discription,
                IsDone=request.IsDone,
                NewCriditUser=user.CreditFinance+request.price,
                price=request.price,
                TimeTransaction = request.TimeTransaction,
                TitleTransaction=request.TitleTransaction
            });

            //2. if isdone ==true , edit user price in User table
            if (request.IsDone)
            {
                var IdEditedUser = _localUser.EditPriceandMessageandpackage (request.IdUser, user.CreditFinance , request.price);
            
            //3. edint in Mongo
            //in below..


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
            await _channeladdkhat.AddToChannelAsync(new TransactionAdd { IdTrans = IdEditedUser }, cancellationToken);
            }
            //
            return new AddTransactionResponse { IdTrans = command };

        }
    }
}
