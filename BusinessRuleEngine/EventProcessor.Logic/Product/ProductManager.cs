using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EventProcessor.Contract.Data;

namespace EventProcessor.Logic.Product
{
    public class ProductManager : IProductManager
    {
        public Task<ProductInfo> GetProduct(int productId)
        {
            //Logic to retrieve product name goes here
            var productName = "Learning to Ski";//Hardcoded on behalf of Logic which returns Product name
            return Task.FromResult(new ProductInfo { ProductId = productId,ProductName = productName});
            
        }
    }
}
