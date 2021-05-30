using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventProcessor.Logic.Emailer
{
    public class EmailSender : IEmailSender
    {
        public Task Send(MailMessage message)
        {
            return Task.CompletedTask;   
        }
    }
}
