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
        //    [Key]
        //    public long Id { get; set; }
        public virtual long IdPackageSMS { get; set; }

        [ForeignKey("IdPackageSMS")]
        public virtual PackageSMS PackageSMS { get; set; }

        public long IdSarKhat { get; set; }
        //public virtual long IdSarKhat { get; set; }
        // [ForeignKey("IdSarKhat")]
        // public virtual SarKhat SarKhat { get; set; }



        public string FarsiTariff { get; set; } 
        public string EnglishTariff { get; set; }



        public virtual ICollection<Users> User { get; set; }
    }
}
