using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.User.Enroll
{
    public class LocalUserMOdel
    {
        public long IdUser { get; set; }
        public string? Phone { get; set; }
        public long IdRole { get; set; }//baraye kam kardane pichidegi
        public int IdUsertype  { get; set; }// haghisgh-hoghoghi
        //14010603
        public long CreditFinance { get; set; }//Etebar// Mr Nazari saied here isnt any things of Wallet to save in here.
        public long CridetMeaasage { get; set; }// 100 message   


    }
    public class PackageTariffModl
    {
        public long Id { get; set; }
        public string TitlePackage { get; set; } //طلایی-نقره ای- برنزی
        public long PricePackage { get; set; }// 300-500-700
        public double ZaridTakhfifPaciTareeffe { get; set; }//zarayeb tareff
    }

}
