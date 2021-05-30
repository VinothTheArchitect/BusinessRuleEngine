using System;

namespace EventProcessor.Contract.Events
{
    public interface IPaymentReceivedEvent
    {
        int CustomerId { get; }

        int ProductId { get; }
    }
}
