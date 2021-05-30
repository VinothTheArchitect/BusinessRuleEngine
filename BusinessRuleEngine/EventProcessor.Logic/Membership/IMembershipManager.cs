using EventProcessor.Contract;
using EventProcessor.Contract.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventProcessor.Logic.Membership
{
    public interface IMembershipManager
    {
        Task Activate(MembershipInfo membershipInfo);

        Task Upgrade(MembershipInfo membershipInfo);
    }
}
