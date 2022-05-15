using ShopsRUsRetailStoreAPI.Data.Entity;
using ShopsRUsRetailStoreAPI.Data.Repository.Abstract;
using ShopsRUsRetailStoreAPI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUsRetailStoreAPI.Services.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<Customer> GetById(string id)
        {
            return await _repository.GetById(id);
        }
    }
}
