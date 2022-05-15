using Moq;
using ShopsRUsRetailStoreAPI.Controllers;
using ShopsRUsRetailStoreAPI.Dto;
using ShopsRUsRetailStoreAPI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace ShopsRUsRetailStoreAPI.Test
{
    public class UnitTest
    {
        [Theory]
        [MemberData(nameof(LoyaltyTestData))]
        public void OneProduct_OnePayment_FullPoint(string name, InvoiceDto invoiceDto, decimal expected)
        {
            var invoiceService = new Mock<IInvoiceService>();

            InvoiceController invoiceController = new InvoiceController(invoiceService.Object);

            var responseDto = invoiceController.CreateBill(invoiceDto).Result;

            Assert.Equal(expected, responseDto.TotalPrice);
        }
        public static IEnumerable<object[]> LoyaltyTestData()
        {
            yield return new object[] { "CustomerOverTwoYears", new InvoiceDto {
                CustomerId= "6280bef63685f5afcff0f9a8" ,
                TotalPrice= 100,
                InvoiceDetails=new List<InvoiceDetailDto>{new InvoiceDetailDto{  Quantity = 1, ProductId="6280bef63685f5afcff0f9a4"}} }
            , 95 };
            yield return new object[] { "EmployeeOfStore", new InvoiceDto {
                CustomerId= "6280bef63685f5afcff0f9a9" ,
                TotalPrice= 100,
                InvoiceDetails=new List<InvoiceDetailDto>{new InvoiceDetailDto{  Quantity = 1, ProductId= "6280bef63685f5afcff0f9a4" } } }
            , 70 };
            yield return new object[] { "AffiliateOfStore", new InvoiceDto {
                CustomerId= "6280bef63685f5afcff0f9aa" ,
                TotalPrice= 100,
                InvoiceDetails=new List<InvoiceDetailDto>{new InvoiceDetailDto{  Quantity = 1, ProductId="6280bef63685f5afcff0f9a4"}} }
            , 90 };
            yield return new object[] { "NewCustomerOnlyDiscountForPrice", new InvoiceDto {
                CustomerId= "6280bf133685f5afcff0f9ab" ,
                TotalPrice= 100,
                InvoiceDetails=new List<InvoiceDetailDto>{new InvoiceDetailDto{  Quantity = 1, ProductId= "6280bef63685f5afcff0f9a4" } } }
            , 95 };
        }
    }
}
