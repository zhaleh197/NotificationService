using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Notification.Domain.Entities.ReadModels;
using Notification.Application.Service.ReadRepository.Common;

namespace Notification.Application.Service.ReadRepository.User
{
    public class ReadUserKhat : BaseReadRepository<KhototUSer>
    {
        public ReadUserKhat(IMongoDatabase db) : base(db)
        {
        }
        public Task ADDKhat(KhototUSer entity, CancellationToken cancellationToken = default)
        {
            return  base.AddAsync(entity, cancellationToken);
        }

        public Task<KhototUSer> GetByKhatIdAsync(long Idkh, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(s => s.id == Idkh, cancellationToken);
        }

        public Task DeleteByKhatIdAsync(long Idkh, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(s => s.id == Idkh, cancellationToken);
        }
    }
}
