using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventProcessor.Logic
{
    public class CustomerManager : ICustomerManager
    {
        public Task GetCustomer(int customerId)
        {
            return Task.CompletedTask;
        }
    }
}
