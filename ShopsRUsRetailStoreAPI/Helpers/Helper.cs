using ShopsRUsRetailStoreAPI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUsRetailStoreAPI.Helpers
{
    public static class Helper
    {
        public static int CalculateRatio(Customer customer)
        {
            int ratio = 0;
            if (customer.IsEmployeeOfStore)
                ratio = 30;
            if (customer.IsAffiliateOfStore)
                ratio = 10;
            if (Helper.IsCustomerOverTwoYears(DateTime.Now, customer.CreatedOn))
                ratio = 5;
            return ratio;
        }
        public static bool IsCustomerOverTwoYears(DateTime startDate, DateTime endDate)
        {
            double totalDays = (endDate - startDate).TotalDays;
            double totalYears = totalDays / 365;
            return totalYears > 2;
        }
        public static decimal CalculateDiscount(decimal price, int ratio)
        {
            decimal discount = 0;

            if (ratio == 0)
                discount = (int)(price / 100) * 5;
            else
                discount = (price / 100) * ratio;

            return discount;
        }
    }
}
