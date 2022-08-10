using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.WriteRepository.Email.Commands
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
    public class EmailSendRequest
    {
        public NetworkCredential from { get; set; }
        public string titleFrom { get; set; }
        public string to { get; set; }
        public string titleTo { get; set; }
        public string subject { get; set; }
        public string message1 { get; set; }
        // public List<IFormFile> Attachments { get; set; }


    }
    public class MailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
   
}
