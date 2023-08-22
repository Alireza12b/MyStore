using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MyStore.Data;
using MyStore.Models;
using System.Data;

namespace MyStore.Repositories.Services
{
    public class ProductRepository
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

        public IDbConnection CreateConnection() => new SqlConnection(_connString);

        private void Save()
        {
            myStrorDbContext.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return myStrorDbContext.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return myStrorDbContext.Categories.ToList().Find(x => x.CategoryId == id);
        }

        public void AddCategory(Category category)
        {
            myStrorDbContext.Categories.Add(category);
            Save();
        }

        public void DeleteCategory(int id)
        {
            myStrorDbContext.Categories.Remove(GetCategoryById(id));
            Save();
        }

        public void UpdateCategory(Category category)
        {
            myStrorDbContext.Categories.Update(category);
            Save();
        }

    }
}
