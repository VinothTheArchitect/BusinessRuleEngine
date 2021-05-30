using EventProcessor.Contract.Events;
using System;
using System.Threading.Tasks;

namespace EventProcessor.Logic.Observable
{
    public interface IPaymentReceivedObservable
    {       
        IDisposable Subscribe(IPaymentReceivedEventObserver observer);

        Task OnPaymentReceived(IPaymentReceivedEvent paymentEvent);
    }
}
