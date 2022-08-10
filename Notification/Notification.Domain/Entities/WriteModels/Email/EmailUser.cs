﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.Email
{
    public class EmailUser
    {
        [Key]
        public long Id { get; set; }
        public long IdUser { get; set; }
        public string Resiver { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime DateSend { get; set; }
        public DateTime DateDelivere { get; set; }
        public string Status { get; set; }
    }
}
