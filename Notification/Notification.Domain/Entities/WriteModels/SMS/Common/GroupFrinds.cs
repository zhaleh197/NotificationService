using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notification.Domain.Entities.Common;
namespace Notification.Domain.Entities.SMS.Common
{
    public class GroupFrinds : BaseEntity<long>
    {
        //    [Key]
        //    public long Id { get; set; }

        //////////// Foreign key   
        public virtual long IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual Users Users { get; set; }
        ////////////
        ///
        //public long IdUser { get; set; }



        public string GroupName { get; set; }

        ////m-n
        //////////// Foreign key   
        //public virtual long PhonebookID { get; set; }
        //[ForeignKey("Id")]
        //public virtual Phonebook Phonebook { get; set; }

        public virtual ICollection<Phonebook> Phonebooks { get; set; }

        ////////////
    }
}
