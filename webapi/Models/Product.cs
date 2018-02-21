using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_MongoDB.Models
{
    public class Product
    {
        public ObjectId Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

    }

    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProduct(string id);

        // add new note document
        Task AddProduct(Product item);

        // remove a single document / note
        Task<bool> RemoveProduct(string id);

        // update just a single document / note
        Task<bool> UpdateProduct(string id, Product item);
        
        //// demo interface - full document update
        //Task<bool> UpdateProductDocument(string id, string body);

        // should be used with high cautious, only in relation with demo setup
        Task<bool> RemoveAllProducts();
    }
}
