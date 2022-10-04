using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.WriteModels.SMS.Common.Khat
{
    public class SpacitalKhotot
    {
    [Key]
    public int Id { get; set; }
    public int LengthofNumber { get; set; }// ham sarkhat ham khat= 300087546532

    public virtual int IdSarKhat { get; set; }//link be sarkhat ha
    //[ForeignKey("Id")]
    [ForeignKey("IdSarKhat")]
    public virtual SarKhat? SarKhat { get; set; }

    public long Price { get; set; }//1 acrite-0 noonActive

}
}
