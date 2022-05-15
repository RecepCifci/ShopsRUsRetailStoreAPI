using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUsRetailStoreAPI.Data.Entity
{
    [BsonIgnoreExtraElements]
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("CreatedOn")]
        public DateTime CreatedOn { get; set; }
        [BsonElement("IsEmployeeOfStore")]
        public bool IsEmployeeOfStore { get; set; }
        [BsonElement("IsAffiliateOfStore")]
        public bool IsAffiliateOfStore { get; set; }

    }
}
