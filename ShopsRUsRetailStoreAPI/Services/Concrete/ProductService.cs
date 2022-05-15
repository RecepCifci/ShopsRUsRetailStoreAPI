using ShopsRUsRetailStoreAPI.Data.Entity;
using ShopsRUsRetailStoreAPI.Data.Repository.Abstract;
using ShopsRUsRetailStoreAPI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUsRetailStoreAPI.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Product> GetById(string id)
        {
            var product = await _repository.GetById(id);

            return product;
        }
        public async Task<List<Product>> GetProductByIdList(List<string> productIdList)
        {
            var product = await _repository.GetProductByIdList(productIdList);

            return product;
        }
    }
}
