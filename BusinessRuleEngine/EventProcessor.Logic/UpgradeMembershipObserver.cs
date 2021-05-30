using EventProcessor.Contract.Data;
using EventProcessor.Contract.Events;
using EventProcessor.Logic.Membership;
using EventProcessor.Logic.Observable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventProcessor.Logic
{
    public class UpgradeMembershipObserver : IPaymentReceivedEventObserver
    {
        private readonly IMembershipManager _membesrshipManager;

        public UpgradeMembershipObserver(IMembershipManager membershipManager)
        {
            _membesrshipManager = membershipManager;
        }
        public async Task OnPaymentReceived(IPaymentReceivedEvent paymentEvent)
        {
            if (paymentEvent.GetType() != typeof(MembershipUpgradePaymentReceivedEvent))
            {
                return;
            }

            var membershipInfo = new MembershipInfo() { CustomerId = paymentEvent.CustomerId };
            await _membesrshipManager.Upgrade(membershipInfo);
        }
    }
}
