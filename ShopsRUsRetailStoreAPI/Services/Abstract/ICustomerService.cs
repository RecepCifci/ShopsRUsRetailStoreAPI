using ShopsRUsRetailStoreAPI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUsRetailStoreAPI.Services.Abstract
{
    public interface ICustomerService
    {
        Task<Customer> GetById(string id);
    }
}
