using ShopsRUsRetailStoreAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUsRetailStoreAPI.Services.Abstract
{
    public interface IInvoiceService
    {
        Task<InvoiceDto> CalculateBill(InvoiceDto invoiceDto);
    }
}
