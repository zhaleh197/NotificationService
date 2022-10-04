using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notification.Domain.Entities.Common;
namespace Notification.Domain.Entities.WriteModels.SMS.Common.Khat
{
    public class SarKhat : BaseEntity<int>
    {
        // public string Type { get; set; }//public-spacial
        //14010402- changed the bool . for permormance
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
}
