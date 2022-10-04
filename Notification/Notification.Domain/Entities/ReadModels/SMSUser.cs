using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.ReadModels
{
    public class SMSUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }

        [BsonElement("IdUser")]
        public long IdUser { get; set; }
        
        [BsonElement("Phone")]
        public string Phone { get; set; }

        [BsonElement("Role")]
        public string Role { get; set; }

        [BsonElement("TitleUsertype")]
        public string TitleUsertype { get; set; }// haghigghi / hoghooghi
       
        [BsonElement("TitlePackage")]
        public string TitlePackage { get; set; } //طلایی-نقره ای- برنزی
        //

        [BsonElement("ZaribTakhfif")] //ضریب تخفیف این پکیج
        public double ZaribTakhfif { get; set; }
        //

        [BsonElement("CreditFinance")]
        public long CreditFinance { get; set; }// موجودی حساب

        [BsonElement("CridetMeaasage")]
        public long CridetMeaasage { get; set; }// موجودی پیام




        //از انجا که مونگودی بی مانند دیتابیس های رابطه ای نسیت.
        //باید از اول مقادیری که ممکن است خالی باشند را اضافه نکنیم.
        //هر جا هر کاربر این مقادیر را اضافه کرد تنها برای ان کار بر اضافه میشود.

        //[BsonElement("khotot")]
        //public List<string> Khotot { get; set; }

        [BsonElement("KhototUser")]
        public List<KhototUSer> KhototUser { get; set; }

        //[BsonElement("DeadlineKhat")]
        //public DateTime DeadlineKhat { get; set; }

        [BsonElement("DocUser")]
        public List<Docclas> DocUser { get; set; }




        //chon shayad hanooz sms ersal nakarde ast. pas inja nazarim.14010426

        //[BsonElement("Body")]
        //public string Body { get; set; }//text
        //[BsonElement("Price")]
        //public int Price { get; set; }// maybe several sms. so Sum of SMS.

        /////////////////////////////////// 



    }


    public class KhototUSer
    {
        public long id { get; set; }
        public long KhatNumber { get; set; }
        public sarkhat SarKhat { get; set; }
        public bool Type { get; set; }//0==Omoomi . 1= Khososi
        public bool Statuse { get; set; }//Active-notAvtive
        public DateTime DedlineKhat { get; set; }// = insert time(NOW) year+1. baraye omoomi =null - baraye khososi = yek sal.

    }
    public class sarkhat
    {
        public int Spacial { get; set; }//public-spacial== public string Type { get; set; }//public-spacial
        public string SarKhatNumber { get; set; }//==1000,2000,3000,... 
        public double BasePrice { get; set; }//هزینه پایه یک پیامک فارسی=77
        public double PersianZarib { get; set; }
        public double EnglishZarib { get; set; }
        public double IranselZarib { get; set; }
        public double HamrahAvalZarib { get; set; }
        public double RaytelZarib { get; set; }
        public double TejasriLinkZarib { get; set; }
    }

    public class Docclas
    {
        public long id { get; set; }
        public string PathofSave { get; set; }
        public bool Confirmcheck { get; set; }//1 taiid 0 bad
        public string TypeofDoc { get; set; }
    }

    public class SMSUserGet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }

        [BsonElement("IdUser")]
        public long IdUser { get; set; }

        [BsonElement("Phone")]
        public string Phone { get; set; }

        [BsonElement("Role")]
        public string Role { get; set; }

        [BsonElement("TitleUsertype")]
        public string TitleUsertype { get; set; }// haghigghi / hoghooghi

        [BsonElement("TitlePackage")]
        public string TitlePackage { get; set; } //طلایی-نقره ای- برنزی
        //

        [BsonElement("ZaribTakhfif")] //ضریب تخفیف این پکیج
        public double ZaribTakhfif { get; set; }
        //

        [BsonElement("CreditFinance")]
        public long CreditFinance { get; set; }// موجودی حساب

        [BsonElement("CridetMeaasage")]
        public long CridetMeaasage { get; set; }// موجودی پیام




        //از انجا که مونگودی بی مانند دیتابیس های رابطه ای نسیت.
        //باید از اول مقادیری که ممکن است خالی باشند را اضافه نکنیم.
        //هر جا هر کاربر این مقادیر را اضافه کرد تنها برای ان کار بر اضافه میشود.

        //[BsonElement("khotot")]
        //public List<string> Khotot { get; set; }

        [BsonElement("khotot")]
        public List<KhototUSer> Khotot { get; set; }

        //[BsonElement("DeadlineKhat")]
        //public DateTime DeadlineKhat { get; set; }

        [BsonElement("DocumentsUser")]
        public List<Docclas> PathDocs { get; set; }




        //chon shayad hanooz sms ersal nakarde ast. pas inja nazarim.14010426

        //[BsonElement("Body")]
        //public string Body { get; set; }//text
        //[BsonElement("Price")]
        //public int Price { get; set; }// maybe several sms. so Sum of SMS.

        /////////////////////////////////// 



    }

}
