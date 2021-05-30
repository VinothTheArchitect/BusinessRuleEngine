using EventProcessor.Contract.Events;
using EventProcessor.Logic.Observable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventReceiver
{
    public interface IPaymentReceivedEventManager
    {
        void Subscribe();

        void Unsubscribe();

        Task OnPaymentReceivedEvent(IPaymentReceivedEvent paymentEvent);
    }
}
