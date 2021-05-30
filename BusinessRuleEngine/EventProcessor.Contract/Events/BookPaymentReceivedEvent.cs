using System;
using System.Collections.Generic;
using System.Text;

namespace EventProcessor.Contract.Events
{
    public class BookPaymentReceivedEvent:IPaymentReceivedEvent
    {
        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public int AgentId { get; set; }
    }
}
