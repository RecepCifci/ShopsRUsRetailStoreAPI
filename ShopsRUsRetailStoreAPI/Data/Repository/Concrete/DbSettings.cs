﻿using ShopsRUsRetailStoreAPI.Data.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUsRetailStoreAPI.Data.Repository.Concrete
{
    public class DbSettings : IDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ProductCollectionName { get; set; }
        public string CustomerCollectionName { get; set; }
        public string DiscountCollectionName { get; set; }
        public string InvoiceCollectionName { get; set; }
        public string InvoiceDetailCollectionName { get; set; }
    }
}
