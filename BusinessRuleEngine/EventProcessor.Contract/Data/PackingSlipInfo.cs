using System;
using System.Collections.Generic;
using System.Text;

namespace EventProcessor.Contract.Data
{
    public class PackingSlipInfo
    {
        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public int? ComplimentaryProductId { get; set; }

    }
}
