using EventProcessor.Contract.Data;
using EventProcessor.Contract.Events;
using EventProcessor.Logic;
using EventProcessor.Logic.Agent;
using EventProcessor.Logic.Membership;
using EventProcessor.Logic.PackingSlip;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EventProcessor.Unit.Tests
{
    public class GenerateDuplicatePackingSlipForRoyaltyDepartmentObserverTests
    {
        private readonly IAgentManager _agentManager = Substitute.For<IAgentManager>();
        private readonly IPackingSlipManager _packingSlipManager = Substitute.For<IPackingSlipManager>();
        private readonly PackingSlipForRoyaltyDepartmentObserver _packingSlipForRoyaltyDepartmentObserver;

        public GenerateDuplicatePackingSlipForRoyaltyDepartmentObserverTests()
        {
            _packingSlipForRoyaltyDepartmentObserver = new PackingSlipForRoyaltyDepartmentObserver(_agentManager, _packingSlipManager);

        }

        [Fact]
        public async Task PaymentReceived_DuplicatePackingSlipForRoyaltyDepartment()
        {
            _packingSlipManager.GenerateForRoyaltyDepartment(Arg.Any<PackingSlipInfo>()).Returns(Task.CompletedTask);

            _agentManager.ProcessCommission(Arg.Any<AgentInfo>(), Arg.Any<double>()).Returns(Task.CompletedTask);

            await _packingSlipForRoyaltyDepartmentObserver.OnPaymentReceived(new BookPaymentReceivedEvent());

            await _packingSlipManager.Received().GenerateForRoyaltyDepartment(Arg.Any<PackingSlipInfo>());

            await _agentManager.Received().ProcessCommission(Arg.Any<AgentInfo>(), Arg.Any<double>());


        }
    }
}
