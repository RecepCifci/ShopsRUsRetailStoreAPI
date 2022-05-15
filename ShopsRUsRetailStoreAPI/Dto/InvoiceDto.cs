using ShopsRUsRetailStoreAPI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUsRetailStoreAPI.Dto
{
    public class InvoiceDto
    {
        public string CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<InvoiceDetailDto> InvoiceDetails { get; set; }
    }
}
