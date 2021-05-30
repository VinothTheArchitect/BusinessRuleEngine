using System;
using System.Collections.Generic;
using System.Text;

namespace EventProcessor.Logic.Emailer
{
    public class MailMessage
    {
        public string From { get; set; }

        public string To { get; set; }

        public string Message { get; set; }
    }
}
