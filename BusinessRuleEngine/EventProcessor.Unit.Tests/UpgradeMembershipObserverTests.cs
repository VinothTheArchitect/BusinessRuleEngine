using EventProcessor.Contract.Data;
using EventProcessor.Contract.Events;
using EventProcessor.Logic;
using EventProcessor.Logic.Membership;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EventProcessor.Unit.Tests
{
    public class UpgradeMembershipObserverTests
    {
        private readonly IMembershipManager _membershipManager = Substitute.For<IMembershipManager>();
        private readonly UpgradeMembershipObserver _upgradeMembershipObserver;

        public UpgradeMembershipObserverTests()
        {
            _upgradeMembershipObserver = new UpgradeMembershipObserver(_membershipManager);

        }

        [Fact]
        public async Task PaymentReceived_MembershipUpgraded()
        {
            _membershipManager.Upgrade(Arg.Any<MembershipInfo>()).Returns(Task.CompletedTask);

            await _upgradeMembershipObserver.OnPaymentReceived(new MembershipUpgradePaymentReceivedEvent());

            await _membershipManager.Received().Upgrade(Arg.Any<MembershipInfo>());
        }
    }
}
