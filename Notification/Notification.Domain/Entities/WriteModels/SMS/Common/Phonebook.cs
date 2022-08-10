using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notification.Domain.Entities.Common;
namespace Notification.Domain.Entities.SMS.Common
{

    public class Phonebook:BaseEntity<long>
    {

        ////    [Key]
        ////    public long Id { get; set; }

        ////////////// Foreign key   
        //public virtual long IdUser { get; set; }
        //[ForeignKey("Id")]
        //public virtual Users Users { get; set; }
        //////////////
        ///
        //public long IdUser { get; set; }




        //public long IdGroup { get; set; }//m-n to Group
        //m-n
        ////////// Foreign key   
        //public virtual long IdGroup { get; set; }
        //[ForeignKey("Id")]
        //public virtual GroupFrinds GroupFrinds { get; set; }
        public virtual ICollection<GroupFrinds> GroupFrinds { get; set; }
        ////////////


        public string Phone { get; set; }
        public string FullName { get; set; }
    }

    //public class Phonebook_Group
    //{
    //    [Key]
    //    public long Id { get; set; }
    //    public long IdGroup { get; set; }
    //    public long IDPhonebook { get; set; }
    //}




}
