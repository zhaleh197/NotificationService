using MongoDB.Driver;
using Notification.Application.Service.ReadRepository.Common;
using Notification.Domain.Entities.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.ReadRepository.User
{
    public class ReadUserDoc : BaseReadRepository<Docclas>
    {
        public ReadUserDoc(IMongoDatabase db) : base(db)
        {
        }


        public Task ADDDoc(Docclas entity, CancellationToken cancellationToken = default)
        {
            return base.AddAsync(entity, cancellationToken);
        }

        public Task<Docclas> GetByDocIdAsync(long IdDoc, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(s => s.id == IdDoc, cancellationToken);
        }

        public Task DeleteByDocIdAsync(long IdDoc, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(s => s.id == IdDoc, cancellationToken);
        }
    }

}