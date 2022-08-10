using MediatR;
using Microsoft.Extensions.Logging;
using Notification.Application.Service.WriteRepository.Email.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.Common.Notification.EmailNotification
{
    public class EmailNotificationHandler : INotificationHandler<EmailNotification>
    {
        private readonly ILogger<EmailNotificationHandler> _logger;
        private readonly IMailService _mailService;

        public EmailNotificationHandler(ILogger<EmailNotificationHandler> logger
            , IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
        }

        public Task Handle(EmailNotification notification, CancellationToken cancellationToken)
        {
            var emailNotification = notification as EmailNotification;
            // sendEmail
            _mailService.SendEmailAsync(new MailRequest { ToEmail = notification.EmailAddress, Body = notification.EmailContent, Subject = notification.Emailsubject });
            _logger.LogWarning("Sending Email to {EmailAddress} with content {EmailContent}", notification.EmailAddress, notification.EmailContent);
            return Task.CompletedTask;
        }
    }
}
