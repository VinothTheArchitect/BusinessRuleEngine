using System;
using System.Collections.Generic;
using System.Text;

namespace EventProcessor.Contract.Events
{
    public class PhysicalProductPaymentReceivedEvent : IPaymentReceivedEvent
    {
        public int CustomerId { get; set; }

        public int AgentId { get; set; }

        public int ProductId { get; set; }
    }
}
