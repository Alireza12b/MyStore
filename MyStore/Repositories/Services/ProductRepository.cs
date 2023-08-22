using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyStore.Data;
using MyStore.Models;
using MyStore.Repositories.Interfaces;
using System.Data;

namespace MyStore.Repositories.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyStrorDbContext myStrorDbContext;
        private readonly IConfiguration _iConfiguration;
        private readonly string _connString;

        public ProductRepository(MyStrorDbContext myStrorDbContext, IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;
            _connString = _iConfiguration.GetConnectionString("DefaultConnection");
            this.myStrorDbContext = myStrorDbContext;
        }

        private IDbConnection CreateConnection() => new SqlConnection(_connString);

        private void Save()
        {
            myStrorDbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var query = "select * from products";
            var connection = CreateConnection();
            var result = connection.Query<Product>(query);
            return result.ToList();
        }

        public Product GetProductById(int id)
        {
            return myStrorDbContext.Products.ToList().Find(x => x.Id == id);
        }

        public void AddProduct(Product category)
        {
            myStrorDbContext.Products.Add(category);
            Save();
        }

        public void DeleteProduct(int id)
        {
            myStrorDbContext.Products.Remove(GetProductById(id));
            Save();
        }

        public void UpdateProduct(Product category)
        {
            myStrorDbContext.Products.Update(category);
            Save();
        }

    }
}
