using MongoDB.Driver;
using Notification.Application.Service.ReadRepository.Common;
using Notification.Domain.Entities.ReadModels;
//using Notification.Domain.Entities.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.ReadRepository.User
{
    public class ReadSMSUser : BaseReadRepository<SMSUser>
    {
        public ReadSMSUser(IMongoDatabase db) : base(db)
        {
        }
        public SMSUser GetByUSerId(long IdUser)
        {
            //var p = Builders<SMSUser>.Projection.Include(x => x.DocUser);
            //var t = base.GetoneFinal(s => s.IdUser == IdUser, p);
            var t = base.Getone(s => s.IdUser == IdUser);
            return t;
        } 
        public Task<SMSUser> GetByUSerIdAsync(long IdUser, CancellationToken cancellationToken = default)
        {
           //return Getone(s => s.IdUser == IdUser);
           var r= base.FirstOrDefaultAsync(s => s.IdUser == IdUser, cancellationToken); 
            // var filter = Builders<SMSUser>.Filter.Where(s => s.IdUser == IdUser);
            return r;

        }
        public Task DeleteByUserIdAsync(long IdUser, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(s => s.IdUser == IdUser, cancellationToken);
        }

        public Task EditUser(SMSUser D, long IdUser, CancellationToken cancellationToken = default)
        {
            var filter= Builders<SMSUser>.Filter.Eq("IdUser", IdUser);
            return base.EditrecordAsync(D, filter, cancellationToken);

            //return base.EditrecordAsync(D,  s => s.IdUser == IdUser, cancellationToken);
        }

        //internal Task EditrecordAsync(UpdateDefinition<SMSUser> update, FilterDefinition<SMSUser> filtr, CancellationToken stoppingToken)
        //{
        //    throw new NotImplementedException();
        //}
    }


}

