using EventProcessor.Contract.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventProcessor.Logic.Emailer
{
    public interface IEmailSender
    {
        Task Send(MembershipInfo membershipInfo, string message);
    }
}
