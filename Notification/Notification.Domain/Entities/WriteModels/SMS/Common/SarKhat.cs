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
    public class SarKhat : BaseEntity<long>
    {
        //    [Key]
        //    public long Id { get; set; }
        //why remove id ??? for BaseEntity<long>

        /// ///


        // public string Type { get; set; }//public-spacial
        //14010402- changed the bool . for permormance
        public bool Spacial { get; set; }//public-spacial== public string Type { get; set; }//public-spacial
        public string SarKhatNumber { get; set; }//==1000,2000,3000,...

        //m-n
        ////////////// Foreign key   
        ////public virtual long IdUser { get; set; }
        //[ForeignKey("Id")]
        //public virtual Users Users { get; set; }
        //////////////
        
       // public virtual ICollection<Users> Users { get; set; }// delet for solve cycle
        public virtual ICollection<KhatSMS> KhatSMS { get; set; }
        //public virtual ICollection<PackageTariff> PackageTariffs { get; set; }

    }
}
