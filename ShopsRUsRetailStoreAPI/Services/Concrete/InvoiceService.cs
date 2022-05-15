using ShopsRUsRetailStoreAPI.Dto;
using ShopsRUsRetailStoreAPI.Helpers;
using ShopsRUsRetailStoreAPI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUsRetailStoreAPI.Services.Concrete
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        public InvoiceService(ICustomerService customerService, IProductService productService)
        {
            _customerService = customerService;
            _productService = productService;
        }
        public async Task<InvoiceDto> CalculateBill(InvoiceDto invoiceDto)
        {
            var customer = await _customerService.GetById(invoiceDto.CustomerId);
            if (customer == null) return invoiceDto;

            decimal totalDiscount = 0;

            int ratio = Helper.CalculateRatio(customer);

            foreach (var invoiceDetail in invoiceDto.InvoiceDetails)
            {
                var product = await _productService.GetById(invoiceDetail.ProductId);

                if (product.IsGroceries) continue;

                totalDiscount += Helper.CalculateDiscount(product.Price * invoiceDetail.Quantity, ratio);
            }
            invoiceDto.TotalPrice -= totalDiscount;
            return invoiceDto;
        }
    }
}
