using System;
using System.Collections.Generic;
using System.Text;

namespace EventProcessor.Contract
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string BillingAddress { get; set; }

    }
}
