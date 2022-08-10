﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.WriteRepository.Email.Commands
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
