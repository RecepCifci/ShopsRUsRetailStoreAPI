using ShopsRUsRetailStoreAPI.Data.Entity;
using ShopsRUsRetailStoreAPI.Data.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace ShopsRUsRetailStoreAPI.Data.Repository.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly IContext _context;
        public ProductRepository(IContext context)
        {
            _context = context;
        }
        public async Task<Product> GetById(string id)
        {
            var product = await _context.Products.Find(x => x.Id == id).FirstOrDefaultAsync();

            return product;
        }
        public async Task<List<Product>> GetProductByIdList(List<string> productIdList)
        {
            var filterDef = new FilterDefinitionBuilder<Product>();
            var filter = filterDef.In(x => x.Id, productIdList);

            var productList = await _context.Products.Find(filter).ToListAsync();
            return productList;
        }
    }
}