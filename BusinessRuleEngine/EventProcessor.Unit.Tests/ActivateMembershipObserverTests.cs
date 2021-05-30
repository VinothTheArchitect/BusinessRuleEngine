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

    public class ActivateMembershipObserverTests
    {
        private readonly IMembershipManager _membershipManager = Substitute.For<IMembershipManager>();
        private readonly ActivateMembershipObserver _activateMembershipObserver;

        public ActivateMembershipObserverTests()
        {
            _activateMembershipObserver = new ActivateMembershipObserver(_membershipManager);
        }

        [Fact]
        public async Task PaymentReceived_MembershipActivated()
        {
            _membershipManager.Activate(Arg.Any<MembershipInfo>()).Returns(Task.CompletedTask);

            await _activateMembershipObserver.OnPaymentReceived(new MembershipPaymentReceivedEvent());

            await _membershipManager.Received().Activate(Arg.Any<MembershipInfo>());
        }
    }
}
