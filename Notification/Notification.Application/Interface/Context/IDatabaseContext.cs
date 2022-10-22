using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Notification.Domain.Entities;
using Notification.Domain.Entities.Common;
using Notification.Domain.Entities.Email;
using Notification.Domain.Entities.Notification;
using Notification.Domain.Entities.SMS;
using Notification.Domain.Entities.SMS.Common; 
using Notification.Domain.Entities.WriteModels.Common;
using Notification.Domain.Entities.WriteModels.Common.BlackList;
using Notification.Domain.Entities.WriteModels.SMS.Common;
using Notification.Domain.Entities.WriteModels.SMS.Common.Khat;
using Notification.Domain.Entities.WriteModels.SMS.Common.OperatorsSMS;
using Notification.Domain.Entities.WriteModels.SMS.QeueSend;
using Notification.Domain.Entities.WriteModels.SMS.SMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Interface.Context
{
    public interface IDatabaseContext 
    {
        /// <summary>
        /// User
        /// </summary>
        public DbSet<EmailUser> EmailUsers { get; set; }
        public DbSet<NotificationUser> NotificationUsers { get; set; }
        //public DbSet<SMSUser> SMSUsers { get; set; }

        public DbSet<QeueEmailUser> QEmailUsers { get; set; }
        public DbSet<QeueNotificationUser> QNotificationUsers { get; set; }
      
        ///

        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<CodeSMS> CodeSMs { get; set; }
        public DbSet<GroupFrinds> GroupFrinds { get; set; }
        public DbSet<Phonebook> Phonebooks { get; set; }
        public DbSet<SarKhat> SarKhats { get; set; }
        public DbSet<StockSMS> StockSMs { get; set; }
        public DbSet<Users> Users { get; set; }



        /// /14010406
        /// 
        
        public DbSet<PackageTariff> PackageTariff { get; set; }
        public DbSet<DocumentsUser> DocumentsUser { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Usertype> Usertype { get; set; }
          
        public DbSet<SMS_Resivers> SMS_Resivers { get; set; }


        //14010503
        public DbSet<QeueofSMS> QeueofSMs { get; set; }

        public DbSet<SpamWords> SpamWords { get; set; }

        //14010606

        public DbSet<Role> Roles { get; set; }
        public DbSet<PatternSMS> PatternSMs { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<KhototUser> KhototUsers { get; set; }
        public DbSet<PublicKhotot> PublicKhotots { get; set; }
        public DbSet<SpacitalKhotot> SpacitalKhotots { get; set; }

        

        public DbSet<TypeSMS> TypeSMS { get; set; }
        public DbSet<PeriodSend> PeriodSend { get; set; }
        public DbSet<SMessageS> SMessageS { get; set; }

        public DbSet<Pishshomareh> Pishshomareh { get; set; }



        public int SaveChanges(bool acceptAllChangesOnSuccess);
        public int SaveChanges();
        public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());



        /// ///////////////////////1401-07-24
        public EntityEntry Entry(object entity);
        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;


        ///////////////////// good things
        /*EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        Task<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default(CancellationToken));
        Task<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default(CancellationToken)) where TEntity : class;
        void AddRange(IEnumerable<object> entities);
        void AddRange(params object[] entities);
        Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default(CancellationToken));
        Task AddRangeAsync(params object[] entities);
        EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry Attach(object entity);
        void AttachRange(params object[] entities);
        void AttachRange(IEnumerable<object> entities);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry Entry(object entity);
        bool Equals(object obj);
        object Find(Type entityType, params object[] keyValues);
        TEntity Find<TEntity>(params object[] keyValues) where TEntity : class;
        Task<TEntity> FindAsync<TEntity>(params object[] keyValues) where TEntity : class;
        Task<object> FindAsync(Type entityType, object[] keyValues, CancellationToken cancellationToken);
        Task<TEntity> FindAsync<TEntity>(object[] keyValues, CancellationToken cancellationToken) where TEntity : class;
        Task<object> FindAsync(Type entityType, params object[] keyValues);
        int GetHashCode();
        DbQuery<TQuery> Query<TQuery>() where TQuery : class;
        EntityEntry Remove(object entity);
        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
        void RemoveRange(IEnumerable<object> entities);
        void RemoveRange(params object[] entities);
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string ToString();
        EntityEntry Update(object entity);
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        void UpdateRange(params object[] entities);
        void UpdateRange(IEnumerable<object> entities);*/
        /////////////////////////////////////////////
    }
}
