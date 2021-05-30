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
    public class GeneratePackingSlipForShippingObserverTests
    {
        private readonly IAgentManager _agentManager = Substitute.For<IAgentManager>();
        private readonly IPackingSlipManager _packingSlipManager = Substitute.For<IPackingSlipManager>();
        private readonly GeneratePackingSlipForShippingObserver _generatePackingSlipForShippingObserver;

        public GeneratePackingSlipForShippingObserverTests()
        {
            _generatePackingSlipForShippingObserver = new GeneratePackingSlipForShippingObserver(_agentManager,_packingSlipManager);

        }

        [Fact]
        public async Task PaymentReceived_PackingSlipForShippingGenerated()
        {
            _packingSlipManager.Generate(Arg.Any<PackingSlipInfo>()).Returns(Task.CompletedTask);

           _agentManager.ProcessCommission(Arg.Any<AgentInfo>(),Arg.Any<double>()).Returns(Task.CompletedTask);

            await _generatePackingSlipForShippingObserver.OnPaymentReceived(new PhysicalProductPaymentReceivedEvent());

            await _packingSlipManager.Received().Generate(Arg.Any<PackingSlipInfo>());

           await _agentManager.Received().ProcessCommission(Arg.Any<AgentInfo>(), Arg.Any<double>());


        }
    }
}
