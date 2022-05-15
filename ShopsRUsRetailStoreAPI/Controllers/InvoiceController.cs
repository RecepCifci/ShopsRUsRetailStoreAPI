using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUsRetailStoreAPI.Dto;
using ShopsRUsRetailStoreAPI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUsRetailStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        [HttpPost]
        public async Task<InvoiceDto> CreateBill(InvoiceDto invoiceDto)
        {
            var response = await _invoiceService.CalculateBill(invoiceDto);
            
            return response;
        }
    }
}

