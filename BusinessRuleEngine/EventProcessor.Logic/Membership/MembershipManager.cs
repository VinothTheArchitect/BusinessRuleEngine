using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EventProcessor.Contract.Data;
using EventProcessor.Logic.Emailer;

namespace EventProcessor.Logic.Membership
{
    public class MembershipManager : IMembershipManager
    {
        private readonly IEmailSender emailSender;
        private readonly ICustomerManager customerManager;

        public MembershipManager(IEmailSender emailSender,ICustomerManager customerManager)
        {
            this.emailSender = emailSender;
            this.customerManager = customerManager;
        }
        public async Task Activate(MembershipInfo membershipInfo)
        {
            //Activation logic goes here
           await  emailSender.Send(new MailMessage() { From = "", To = "", Message = "" });
        }

        public async Task Upgrade(MembershipInfo membershipInfo)
        { 
            //upgrade logic goes here
            await emailSender.Send(new MailMessage() { From = "", To = "", Message = "" });
        }
    }
}
