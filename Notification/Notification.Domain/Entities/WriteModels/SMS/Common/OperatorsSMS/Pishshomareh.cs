using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.WriteModels.SMS.Common.OperatorsSMS
{
    public class Pishshomareh
    {
        [Key]
        public int Id { get; set; }
        public string Pishshomare { get; set; }
        public string Operator { get; set; }
        public int idOperator { get; set; }
        public string? Discription { get; set; }
    }
}
