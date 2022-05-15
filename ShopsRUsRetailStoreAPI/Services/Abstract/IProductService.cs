using ShopsRUsRetailStoreAPI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUsRetailStoreAPI.Services.Abstract
{
    public interface IProductService
    {
        Task<Product> GetById(string id);
        Task<List<Product>> GetProductByIdList(List<string> productIdList);
    }
}
