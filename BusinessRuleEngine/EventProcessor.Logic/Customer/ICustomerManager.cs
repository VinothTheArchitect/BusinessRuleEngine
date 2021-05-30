using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventProcessor.Logic
{
    public interface ICustomerManager
    {
        Task GetCustomer(int customerId);
    }
}
