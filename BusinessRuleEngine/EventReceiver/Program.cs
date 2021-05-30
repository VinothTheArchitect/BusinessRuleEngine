using EventProcessor.Logic.Agent;
using EventProcessor.Logic.Emailer;
using EventProcessor.Logic.Membership;
using EventProcessor.Logic.Observable;
using EventProcessor.Logic.PackingSlip;
using EventProcessor.Logic.Product;
using EventProcessor.Logic;
using System;
using EventProcessor.Contract.Events;

namespace EventReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            IPaymentReceivedObservable provider = new PaymentReceivedObservable() ;
            IPackingSlipManager packingSlipManager = new PackingSlipManager();
            IAgentManager agentManager = new AgentManager();
            IProductManager productManager = new ProductManager();
            IMembershipManager membershipManager = new MembershipManager(new EmailSender(),new CustomerManager());

            IPaymentReceivedEventManager paymentEventManager = new PaymentReceivedEventManager(provider,packingSlipManager,agentManager,productManager,membershipManager);

            paymentEventManager.Subscribe();

            //Physical product event
            paymentEventManager.OnPaymentReceivedEvent(new PhysicalProductPaymentReceivedEvent() {AgentId=1,CustomerId=1,ProductId = 1 });

            //Book Event
            paymentEventManager.OnPaymentReceivedEvent(new BookPaymentReceivedEvent() { AgentId = 1, CustomerId = 1, ProductId = 1 });

            //Video event
            paymentEventManager.OnPaymentReceivedEvent(new VideoPaymentReceivedEvent() { CustomerId=1,ProductId = 1});

            //Membership activate event
            paymentEventManager.OnPaymentReceivedEvent(new MembershipPaymentReceivedEvent() { CustomerId = 1, ProductId = 1 });

            //Membership upgrade event
            paymentEventManager.OnPaymentReceivedEvent(new MembershipUpgradePaymentReceivedEvent() { CustomerId = 1, ProductId = 1 });

            paymentEventManager.Unsubscribe();
        }
        
    }
}
