using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notification.Domain.Entities.Common;
namespace Notification.Domain.Entities.SMS.Common
{
    public class PackageSMS: BaseEntity<long>
    {
        //[Key]
        //public long Id { get; set; }
        public string TitlePackage { get; set; } //طلایی-نقره ای- برنزی
        public long PricePackage { get; set; }// 300-500-700


        public virtual ICollection<PackageTariff> PackageTariffs { get; set; }
    }
}
