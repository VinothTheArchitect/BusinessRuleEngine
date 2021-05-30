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
    public class PackingSlipForRoyaltyDepartmentObserver : IPaymentReceivedEventObserver
    {
        private readonly IAgentManager _agentManager;
        private readonly IPackingSlipManager _packingSlipManager;

        public PackingSlipForRoyaltyDepartmentObserver(IAgentManager agentManager,IPackingSlipManager packingSlipManager )
        {
            _agentManager = agentManager;
            _packingSlipManager = packingSlipManager;
        }
        public async Task OnPaymentReceived(IPaymentReceivedEvent paymentEvent)
        {

            if (!(paymentEvent is BookPaymentReceivedEvent bookPaymentEvent))
            {
                return;
            }
            
            var packingSlipInfo = new PackingSlipInfo { CustomerId = bookPaymentEvent.CustomerId, ProductId = bookPaymentEvent.ProductId};
            await _packingSlipManager.GenerateForRoyaltyDepartment(packingSlipInfo);

            var agentInfo = new AgentInfo {AgentId = bookPaymentEvent.AgentId };
            await _agentManager.ProcessCommission(agentInfo, 250);

        }
    }
}
