using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.WriteRepository.User.Kat.SarKhat
{
    public class SarKhatModel
    {
        public long Id { get; set; }
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
