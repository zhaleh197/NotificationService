using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.Common.Notification.EmailNotification
{
    public class EmailNotification : INotification
    {
        public string EmailAddress { get; set; }
        public string EmailContent { get; set; }
        public string Emailsubject { get; set; }

        public EmailNotification(string emailAddress, string emailContent, string subject)
        {
            EmailAddress = emailAddress;
            EmailContent = emailContent;
            Emailsubject = subject;
        }


    }
}