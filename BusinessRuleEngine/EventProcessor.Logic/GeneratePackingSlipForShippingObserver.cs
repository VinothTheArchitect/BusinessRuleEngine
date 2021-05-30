using EventProcessor.Contract.Data;
using EventProcessor.Contract.Events;
using EventProcessor.Logic.Agent;
using EventProcessor.Logic.Observable;
using EventProcessor.Logic.PackingSlip;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventProcessor.Logic
{
    public class GeneratePackingSlipForShippingObserver: IPaymentReceivedEventObserver
    {
        private readonly IAgentManager _agentManager;
        private readonly IPackingSlipManager _packingSlipManager;

        public GeneratePackingSlipForShippingObserver(IAgentManager agentManager, IPackingSlipManager packingSlipManager)
        {
            _agentManager = agentManager;
            _packingSlipManager = packingSlipManager;
        }
        public async Task OnPaymentReceived(IPaymentReceivedEvent paymentEvent)
        {

            if (!(paymentEvent is PhysicalProductPaymentReceivedEvent physicalProductPaymentEvent))
            {
                return;
            }

            var packingSlipInfo = new PackingSlipInfo { CustomerId = physicalProductPaymentEvent.CustomerId, ProductId = physicalProductPaymentEvent.ProductId };
            await _packingSlipManager.Generate(packingSlipInfo);

            var agentInfo = new AgentInfo { AgentId = physicalProductPaymentEvent.AgentId };
            await _agentManager.ProcessCommission(agentInfo, 200);//Hardcoded commission amount for timebeing
        }
    }
}
