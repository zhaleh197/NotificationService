using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System;
//using System.Collections.Generic;
//using System.Linq; 
//using System.Threading.Tasks;
//using System.Data;
//using System.Data.Common;
//using Microsoft.Data.SqlClient;
////using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Dapper;
using Notification.Domain.Entities.Email;
using Notification.Domain.Entities.Notification;
using Notification.Domain.Entities.SMS;
using Notification.Application.Interface.Context;
using Notification.Domain.Entities.SMS.Common;
using Notification.Domain.Entities;
using Notification.Domain.Entities.SMS.SMS;
using Notification.Domain.Entities.SMS.QeueSend;
using Notification.Domain.Entities.Common;
using Notification.Domain.Entities.WriteModels.SMS.QeueSend;
using Notification.Domain.Entities.WriteModels.Common.BlackList;

namespace Notification.Persistance.Context
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext()
        {
        }
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("A FALLBACK CONNECTION STRING");
            }
        }
         
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




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PackageTariff>()
              .HasData(
               new PackageTariff { Id = 1, IdPackageSMS = 1, EnglishTariff = "25", FarsiTariff = "30", IdSarKhat = 1, InsertTime = DateTime.Now, IsRemoved = false },
               new PackageTariff { Id = 2, IdPackageSMS = 2, EnglishTariff = "35", FarsiTariff = "40", IdSarKhat = 2, InsertTime = DateTime.Now, IsRemoved = false },
               new PackageTariff { Id = 3, IdPackageSMS = 3, EnglishTariff = "45", FarsiTariff = "50", IdSarKhat = 3, InsertTime = DateTime.Now, IsRemoved = false }
               );
            modelBuilder.Entity<PackageSMS>()
                        .HasData(
                         new PackageSMS { Id = 1, InsertTime = DateTime.Now, IsRemoved = false, PricePackage = 100000, TitlePackage = "Golden" },
                         new PackageSMS { Id = 2, InsertTime = DateTime.Now, IsRemoved = false, PricePackage = 75000, TitlePackage = "Silver" },
                         new PackageSMS { Id = 3, InsertTime = DateTime.Now, IsRemoved = false, PricePackage = 50000, TitlePackage = "Bronze" }
                         );

            modelBuilder.Entity<SarKhat>()
                     .HasData(
                      new SarKhat { Id = 1, SarKhatNumber = "1000", Spacial = true, IsRemoved = false, InsertTime = DateTime.Now },
                      new SarKhat { Id = 2, SarKhatNumber = "2000", Spacial = false, IsRemoved = false, InsertTime = DateTime.Now },
                      new SarKhat { Id = 3, SarKhatNumber = "3000", Spacial = false, IsRemoved = false, InsertTime = DateTime.Now }
                      );
            modelBuilder.Entity<Usertype>()
                    .HasData(
                     new Usertype { Id = 1, Title = "Real", InsertTime = DateTime.Now, IsRemoved = false },
                     new Usertype { Id = 2, Title = "Legal", InsertTime = DateTime.Now, IsRemoved = false }
                     );
            modelBuilder.Entity<SpamWords>()
                  .HasData(
                   new SpamWords { Id = 1,Word="Daesh"},
                   new SpamWords { Id = 2, Word = "داعش" },
                   new SpamWords { Id = 3, Word = "جنبش" },
                   new SpamWords { Id = 4, Word = "دموکرات" },
                   new SpamWords { Id = 5, Word = "اوجالان" },
                   new SpamWords { Id = 6, Word = "قاضی" },
                   new SpamWords { Id =7, Word = "Demokrat" },
                   new SpamWords { Id = 8, Word = "Ghazi" },
                   new SpamWords { Id =9, Word = "Komala" },
                   new SpamWords { Id = 10, Word = "Dolat" }
                 );
        }


    }
}
