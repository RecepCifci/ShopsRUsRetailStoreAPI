using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUsRetailStoreAPI.Dto
{
    public class InvoiceDetailDto
    {
        public int Quantity { get; set; }
        public string ProductId { get; set; }
        private decimal Price { get; }
    }
}
