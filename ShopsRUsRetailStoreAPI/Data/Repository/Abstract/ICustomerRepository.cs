using ShopsRUsRetailStoreAPI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUsRetailStoreAPI.Data.Repository.Abstract
{
    public interface ICustomerRepository
    {
        Task<Customer> GetById(string id);
    }
}
