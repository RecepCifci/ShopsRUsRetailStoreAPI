using ShopsRUsRetailStoreAPI.Data.Entity;
using ShopsRUsRetailStoreAPI.Data.Repository.Abstract;
using System;
using System.Collections.Generic;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace ShopsRUsRetailStoreAPI.Data.Repository.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IContext _context;
        public CustomerRepository(IContext context)
        {
            _context = context;
        }
        public async Task<Customer> GetById(string id)
        {
            var customer = await _context.Customers.Find(x => x.Id == id).FirstOrDefaultAsync();

            return customer;
        }
    }
}
