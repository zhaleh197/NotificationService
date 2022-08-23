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
        public Task<SMSUser> GetByUSerIdAsync(long IdUser, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(s => s.IdUser == IdUser, cancellationToken);
        }
        public Task DeleteByUserIdAsync(long IdUser, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(s => s.IdUser == IdUser, cancellationToken);
        }

        public Task EditUser(SMSUser D, long IdUser, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(D, s => s.IdUser == IdUser, cancellationToken);
        }

    }


}

