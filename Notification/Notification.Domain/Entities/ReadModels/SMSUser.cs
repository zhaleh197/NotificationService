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

        [BsonElement("TitleUsertype")]
        public string TitleUsertype { get; set; }// haghigghi / hoghooghi
       
        [BsonElement("TitlePackage")]
        public string TitlePackage { get; set; } //طلایی-نقره ای- برنزی
        
        [BsonElement("PricePackage")]
        public long PricePackage { get; set; }// 300-500-700
        
        [BsonElement("Spacial")]
        public bool Spacial { get; set; }//public-spacial== public string Type { get; set; }//public-spacial
       
        [BsonElement("SarKhatNumber")]
        public string SarKhatNumber { get; set; }//==1000,2000,3000,...

        [BsonElement("FarsiTariff")]
        public string FarsiTariff { get; set; }

        [BsonElement("EnglishTariff")]
        public string EnglishTariff { get; set; }

        [BsonElement("DeadlinePackage")]
        public DateTime DeadlinePackage { get; set; }

        [BsonElement("PathDocs")]
        public string PathDocs { get; set; }


        //chon shayad hanooz sms ersal nakarde ast. pas inja nazarim.14010426

        //[BsonElement("Body")]
        //public string Body { get; set; }//text
        //[BsonElement("Price")]
        //public int Price { get; set; }// maybe several sms. so Sum of SMS.

        ///////////////////////////////////
    }
}
