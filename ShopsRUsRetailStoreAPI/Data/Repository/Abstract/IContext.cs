using MongoDB.Driver;
using ShopsRUsRetailStoreAPI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUsRetailStoreAPI.Data.Repository.Abstract
{
    public interface IContext
    {
        public IMongoCollection<Product> Products { get; }
        public IMongoCollection<Customer> Customers { get; }
    }
}
