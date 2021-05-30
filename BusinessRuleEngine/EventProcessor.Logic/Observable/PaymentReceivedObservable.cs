using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EventProcessor.Contract.Events;

namespace EventProcessor.Logic.Observable
{
    public class PaymentReceivedObservable : IPaymentReceivedObservable
    {
        private readonly List<IPaymentReceivedEventObserver> _observers;
        
        public PaymentReceivedObservable()
        {
            _observers = new List<IPaymentReceivedEventObserver>();
        }        

        public async Task OnPaymentReceived(IPaymentReceivedEvent paymentReceivedEvent)
        {
            if (_observers.Count == 0)
            {
                return;
            }

            foreach (var observer in _observers)
            {
                try
                {
                    await observer.OnPaymentReceived(paymentReceivedEvent);
                }
                catch (Exception ex)
                {
                    //Exception Handling
                }
            }
        }

        public IDisposable Subscribe(IPaymentReceivedEventObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);                
            }

            return new PaymentReceivedEventUnsubscriber(_observers,observer);
        }

        private class PaymentReceivedEventUnsubscriber : IDisposable
        {
            private readonly List<IPaymentReceivedEventObserver> _observers;
            private readonly IPaymentReceivedEventObserver _observer;

            public PaymentReceivedEventUnsubscriber(List<IPaymentReceivedEventObserver> observers, IPaymentReceivedEventObserver observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                {
                    _observers.Remove(_observer);
                }
            }
        }
    }
}
