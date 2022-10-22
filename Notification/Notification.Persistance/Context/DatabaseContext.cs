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
using Notification.Domain.Entities.Common;
using Notification.Domain.Entities.WriteModels.SMS.QeueSend;
using Notification.Domain.Entities.WriteModels.Common.BlackList;
using Notification.Domain.Entities.WriteModels.Common; 
using Notification.Domain.Entities.WriteModels.SMS.Common;
using Notification.Domain.Entities.WriteModels.SMS.Common.Khat;
using Notification.Domain.Entities.WriteModels.SMS.SMS;
using Notification.Domain.Entities.WriteModels.SMS.Common.OperatorsSMS;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
        //public DbSet<SMSUser> SMSUsers { get; set; }

        public DbSet<QeueEmailUser> QEmailUsers { get; set; }
        public DbSet<QeueNotificationUser> QNotificationUsers { get; set; }
        


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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>()
            .HasData(
             new Role { Id = 1, Title = "مدیر" },
             new Role { Id = 2, Title = "کاربر" },
             new Role { Id = 3, Title = "اپراتور" }
             );

            modelBuilder.Entity<DocumentType>()
              .HasData(
               new DocumentType { Id = 1,Title="مدارک احراز هویت" },
               new DocumentType { Id = 2,Title= "شناسنامه" },
               new DocumentType { Id = 3,Title= "کارت ملی" },
               new DocumentType { Id = 4, Title = "فیش پرداختی" },
               new DocumentType { Id = 5, Title = "جواز" },
               new DocumentType { Id = 6,Title = "خرید خط" }
               );


            modelBuilder.Entity<PatternSMS>()
             .HasData(
              new PatternSMS { Id = 1, TitlePattern = "وریفای", NumberofVariable=1,TextPatern="  کد تایید شما = %1% است.",InsertTime=DateTime.Now,IsRemoved=false },
              new PatternSMS { Id = 2, TitlePattern = "خوش امد گویی", NumberofVariable = 1, TextPatern = " به اپلیکیشن %1% خوش امدید.", InsertTime = DateTime.Now, IsRemoved = false },
              new PatternSMS { Id = 3, TitlePattern = "خوش امد گویی  کاربر خاص", NumberofVariable = 2, TextPatern = "  سلام. %1% عزیز به اپلیکیشن %2% خوش آمدید.", InsertTime = DateTime.Now, IsRemoved = false }

              );

            modelBuilder.Entity<TypeSMS>()
             .HasData(
              new TypeSMS { Id = 1, Name = "رمز پویا", Periority=1  ,Confirm=true},
              new TypeSMS { Id = 2, Name = "لاگین", Periority = 1, Confirm = true },
              new TypeSMS { Id = 3, Name = "فراموشی رمز", Periority = 1, Confirm = true },
              new TypeSMS { Id = 4, Name = "اطلاع رسانی", Periority = 3, Confirm = true },
              new TypeSMS { Id = 5, Name = "پیام خیلی ضروری", Periority = 1, Confirm = false },
              new TypeSMS { Id = 6, Name = "سایر-عادی", Periority = 3, Confirm = true }
              );

            modelBuilder.Entity<PeriodSend>()
              .HasData(
               new PeriodSend { Id = 1, Name = "Once" },
                new PeriodSend { Id = 2, Name = "Hourly" },
               new PeriodSend { Id = 3, Name = "Daily" },
                new PeriodSend { Id = 4, Name = "Weekly" },
               new PeriodSend { Id = 5, Name = "Mounthly" },
               new PeriodSend { Id =6, Name = "Annoual" }
               );

            modelBuilder.Entity<PublicKhotot>()
           .HasData(
            new PublicKhotot { Id = 1, IdSarKhat=1,LengthofNumber=10,LineNumber=1000123456,Statue=true},
            new PublicKhotot { Id = 2, IdSarKhat = 2, LengthofNumber = 12, LineNumber = 200012345678, Statue = true },
            new PublicKhotot { Id = 3, IdSarKhat = 2, LengthofNumber = 14, LineNumber = 30001234567890, Statue = true }


            );
            modelBuilder.Entity<SpacitalKhotot>()
         .HasData(
                //1000
          new SpacitalKhotot { Id = 1, IdSarKhat = 1, LengthofNumber = 10, Price= 8000000  },
          new SpacitalKhotot { Id = 2, IdSarKhat = 1, LengthofNumber = 12, Price=400000},
          new SpacitalKhotot { Id = 3, IdSarKhat = 1, LengthofNumber = 14, Price=200000 },
          //3000
          new SpacitalKhotot { Id = 4, IdSarKhat = 2, LengthofNumber = 10, Price = 8000000 },
          new SpacitalKhotot { Id = 5, IdSarKhat = 2, LengthofNumber = 12, Price = 400000 },
          new SpacitalKhotot { Id = 6, IdSarKhat = 2, LengthofNumber = 14, Price = 200000 },
          //5000
          new SpacitalKhotot { Id = 7, IdSarKhat = 3, LengthofNumber = 10, Price = 8000000 },
          new SpacitalKhotot { Id = 8, IdSarKhat = 3, LengthofNumber = 12, Price = 400000 },
          new SpacitalKhotot { Id = 9, IdSarKhat = 3, LengthofNumber = 14, Price = 200000 }


          );
            modelBuilder.Entity<PackageTariff>()
              .HasData(
               new PackageTariff { Id = 1, PricePackage = 100000, TitlePackage = "Golden",ZaridTakhfifPaciTareeffe=0.8 },
               new PackageTariff { Id = 2, PricePackage = 75000, TitlePackage = "Silver" , ZaridTakhfifPaciTareeffe = 0.9 },
               new PackageTariff { Id = 3, PricePackage = 50000, TitlePackage = "Bronze" , ZaridTakhfifPaciTareeffe = 0.95 },
               new PackageTariff { Id = 4, PricePackage = 0, TitlePackage = "Ziro", ZaridTakhfifPaciTareeffe = 1 }
               ); 

            modelBuilder.Entity<SarKhat>()
                     .HasData(
                      new SarKhat { Id = 1, SarKhatNumber = "1000", Spacial = 1, BasePrice = 77,   PersianZarib = 1, EnglishZarib = 1.2, HamrahAvalZarib = 1, IranselZarib = 1.2, RaytelZarib = 1.5, TejasriLinkZarib = 1.9 },
                      new SarKhat { Id = 2, SarKhatNumber = "2000", Spacial = 2, BasePrice = 82,   PersianZarib = 1, EnglishZarib = 1.2, HamrahAvalZarib = 1, IranselZarib = 1.2, RaytelZarib = 1.5, TejasriLinkZarib = 1.9 },
                      new SarKhat { Id = 3, SarKhatNumber = "3000", Spacial = 2, BasePrice = 77.6, PersianZarib = 1, EnglishZarib = 1.2, HamrahAvalZarib = 1, IranselZarib = 1.2, RaytelZarib = 1.5, TejasriLinkZarib = 1.9 },
                      new SarKhat { Id = 4, SarKhatNumber = "5000", Spacial = 3, BasePrice = 77.6, PersianZarib = 1, EnglishZarib = 1.2, HamrahAvalZarib = 1, IranselZarib = 1.2, RaytelZarib = 1.5, TejasriLinkZarib = 1.9 }
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

            modelBuilder.Entity<Pishshomareh>()
              .HasData(
               new Pishshomareh { Id = 1, Operator = "همراه اول",Pishshomare="918" ,idOperator=1},
               new Pishshomareh { Id = 2, Operator = "همراه اول", Pishshomare = "917" ,idOperator = 1 },
               new Pishshomareh { Id = 3, Operator = "همراه اول", Pishshomare = "916", idOperator = 1 },
               new Pishshomareh { Id = 4, Operator = "همراه اول", Pishshomare = "915", idOperator = 1 },
               new Pishshomareh { Id = 5, Operator = "همراه اول", Pishshomare = "914", idOperator = 1 },
               new Pishshomareh { Id = 6, Operator = "همراه اول", Pishshomare = "913", idOperator = 1 },
               new Pishshomareh { Id = 7, Operator = "همراه اول", Pishshomare = "912", idOperator = 1 },
               new Pishshomareh { Id = 8, Operator = "همراه اول", Pishshomare = "911", idOperator = 1 },
               new Pishshomareh { Id = 9, Operator = "همراه اول", Pishshomare = "910", idOperator = 1 },
               new Pishshomareh { Id = 10, Operator = "همراه اول", Pishshomare = "990", idOperator = 1 },
               new Pishshomareh { Id = 11, Operator = "همراه اول", Pishshomare = "991", idOperator = 1 },
               new Pishshomareh { Id = 12, Operator = "همراه اول", Pishshomare = "992", idOperator = 1 },
               new Pishshomareh { Id = 13, Operator = "همراه اول", Pishshomare = "993", idOperator = 1 },
               new Pishshomareh { Id = 14, Operator = "همراه اول", Pishshomare = "994", idOperator = 1 },
               new Pishshomareh { Id = 15, Operator = "ایرانسل", Pishshomare = "901" , idOperator =2 },
               new Pishshomareh { Id = 16, Operator = "ایرانسل", Pishshomare = "902", idOperator = 2 },
               new Pishshomareh { Id = 17, Operator = "ایرانسل", Pishshomare = "903", idOperator = 2 },
               new Pishshomareh { Id = 18, Operator = "ایرانسل", Pishshomare = "904", idOperator = 2 },
               new Pishshomareh { Id = 19, Operator = "ایرانسل", Pishshomare = "905", idOperator = 2 },
               new Pishshomareh { Id = 20, Operator = "ایرانسل", Pishshomare = "933", idOperator = 2 },
                new Pishshomareh { Id = 21, Operator = "ایرانسل", Pishshomare = "935", idOperator = 2 },
               new Pishshomareh { Id = 22, Operator = "ایرانسل", Pishshomare = "936", idOperator = 2 },
               new Pishshomareh { Id = 23, Operator = "ایرانسل", Pishshomare = "937", idOperator = 2 },
               new Pishshomareh { Id = 24, Operator = "ایرانسل", Pishshomare = "938", idOperator = 2 },
               new Pishshomareh { Id = 25, Operator = "ایرانسل", Pishshomare = "939", idOperator = 2 },
               new Pishshomareh { Id = 26, Operator = "ایرانسل", Pishshomare = "930", idOperator = 2 },
               new Pishshomareh { Id = 27, Operator = "شاتل", Pishshomare = "922", idOperator = 3 },
               new Pishshomareh { Id = 28, Operator = "شاتل", Pishshomare = "921", idOperator = 3 },
               new Pishshomareh { Id = 29, Operator = "شاتل", Pishshomare = "920", idOperator = 3 },
               new Pishshomareh { Id =30, Operator = "سایر", Pishshomare = "904", idOperator = 4 }

             );

        }



        //درست شد. اد دیبی کانتکس تابع دا در ای دیتابس کانتکس اد کردم.

        /// <summary>
        /// این را برای رفرش دیتابیس میخوایتم ولی اشتباه است  میبایست خودش میداشت. الان من اینجا اصلا پیاده سازی نکردم همیجوری نوشتم.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="res"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        //object IDatabaseContext.Entry<T>(T res)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
