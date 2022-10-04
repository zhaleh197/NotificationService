using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.WriteModels.Common.BlackList
{
    public class SpamWords
    {
        [Key]
        public long Id { get; set; }
        public string Word { get; set; }

    }
}
