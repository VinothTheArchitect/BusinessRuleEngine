using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EventProcessor.Contract.Events;
using EventProcessor.Logic.Observable;
using EventProcessor.Logic;
using EventProcessor.Logic.PackingSlip;
using EventProcessor.Logic.Agent;
using EventProcessor.Logic.Product;
using EventProcessor.Logic.Membership;

namespace EventReceiver
{
    public class PaymentReceivedEventManager : IPaymentReceivedEventManager
    {
        private List<IDisposable> _subscriptions;
        private readonly IPackingSlipManager _packingSlipManager;
        private readonly IAgentManager _agentManager;
        private readonly IProductManager _productManager;
        private readonly IMembershipManager _membershipManager;
        public IPaymentReceivedObservable _provider;


        public async Task OnPaymentReceivedEvent(IPaymentReceivedEvent paymentEvent)
        {
            await _provider.OnPaymentReceived(paymentEvent);
        }

        public PaymentReceivedEventManager(IPaymentReceivedObservable provider, IPackingSlipManager packingSlipManager, IAgentManager agentManager, IProductManager productManager, IMembershipManager membershipManager)
        {
            _subscriptions = new List<IDisposable>();
            _provider = provider;

            _packingSlipManager = packingSlipManager;
            _agentManager = agentManager;
            _productManager = productManager;
            _membershipManager = membershipManager;
        }

        public void Subscribe()
        {
            if (_provider != null)
            {
                _subscriptions.Add(_provider.Subscribe(new GeneratePackingSlipForShippingObserver(_agentManager,_packingSlipManager)));
                _subscriptions.Add(_provider.Subscribe(new PackingSlipForRoyaltyDepartmentObserver(_agentManager, _packingSlipManager)));
                _subscriptions.Add(_provider.Subscribe(new ActivateMembershipObserver(_membershipManager)));
                _subscriptions.Add(_provider.Subscribe(new UpgradeMembershipObserver(_membershipManager)));
                _subscriptions.Add(_provider.Subscribe(new VideoPaymentObserver(_packingSlipManager, _productManager)));
            }
        }

        public void Unsubscribe()
        {
            if (_provider != null)
            {
                foreach (var subscription in _subscriptions)
                {
                    if (subscription != null)
                    {
                        subscription.Dispose();
                    }
                }
                _subscriptions?.Clear();
            }
        }
    }
}
