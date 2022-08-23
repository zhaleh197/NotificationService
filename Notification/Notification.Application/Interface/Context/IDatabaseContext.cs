using Microsoft.EntityFrameworkCore;
using Notification.Domain.Entities;
using Notification.Domain.Entities.Common;
using Notification.Domain.Entities.Email;
using Notification.Domain.Entities.Notification;
using Notification.Domain.Entities.SMS;
using Notification.Domain.Entities.SMS.Common;
using Notification.Domain.Entities.SMS.QeueSend;
using Notification.Domain.Entities.SMS.SMS;
using Notification.Domain.Entities.WriteModels.Common.BlackList;
using Notification.Domain.Entities.WriteModels.SMS.QeueSend;
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
        public DbSet<SMSUser> SMSUsers { get; set; }

        public DbSet<QeueEmailUser> QEmailUsers { get; set; }
        public DbSet<QeueNotificationUser> QNotificationUsers { get; set; }
        public DbSet<QeueSMS> QSMSUsers { get; set; }

        /// <summary>
        /// Client
        /// </summary>

        public DbSet<EmailClient> EmailClients { get; set; }
        public DbSet<NotificationClient> NotificationClients { get; set; }
        public DbSet<SMSClient> SMSClients { get; set; }

        public DbSet<QeueEmailClient> QEmailClients { get; set; }
        public DbSet<QeueNotificationClient> QNotificationClient { get; set; }
        public DbSet<QeueSMSClient> QSMSClient { get; set; }

        ////
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
         
        public DbSet<KhatSMS> KhatSMS { get; set; }
        public DbSet<PackageSMS> PackageSMS { get; set; }
        public DbSet<SMS_Resivers> SMS_Resivers { get; set; }

        //14010503
        public DbSet<QeueofSMS> QeueofSMs { get; set; }

        public DbSet<SpamWords> SpamWords { get; set; }









        public int SaveChanges(bool acceptAllChangesOnSuccess);
        public int SaveChanges();
        public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());




    }
}
