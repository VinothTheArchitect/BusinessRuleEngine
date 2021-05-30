using EventProcessor.Contract.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventProcessor.Logic.Product
{
    public interface IProductManager
    {
        Task<ProductInfo> GetProduct(int productId);
    }
}
