using System;
using System.Collections.Generic;
using System.Text;

namespace EventProcessor.Contract.Events
{
    public class VideoPaymentReceivedEvent : IPaymentReceivedEvent
    {
        public int CustomerId { get; set; }

        public int ProductId { get; set; }

    }
}
