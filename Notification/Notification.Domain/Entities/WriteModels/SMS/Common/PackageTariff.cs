using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notification.Domain.Entities.Common;
namespace Notification.Domain.Entities.SMS.Common
{
    public class PackageTariff: BaseEntity<long>
    {
        public string TitlePackage { get; set; } //طلایی-نقره ای- برنزی
        public long PricePackage { get; set; }// 300-500-700

        public double ZaridTakhfifPaciTareeffe { get; set; }//zarayeb tareff

        //public double FarsiTariff { get; set; }//zarayeb tareff
        //public double EnglishTariff { get; set; }//zarayeb tareffe

        public virtual ICollection<Users> User { get; set; }
    }
}
