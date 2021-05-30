using EventProcessor.Contract.Events;
using System.Threading.Tasks;

namespace EventProcessor.Logic.Observable
{
    public interface IPaymentReceivedEventObserver
    {
        Task OnPaymentReceived(IPaymentReceivedEvent paymentEvent);
    }
}
