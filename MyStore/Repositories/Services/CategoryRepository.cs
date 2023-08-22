using MyStore.Data;
using MyStore.Models;
using MyStore.Repositories.Interfaces;

namespace MyStore.Repositories.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyStrorDbContext myStoreDbContext;

        public CategoryRepository(MyStrorDbContext myStoreDbContext)
        {
            this.myStoreDbContext = myStoreDbContext;
        }

        private void Save()
        {
            myStoreDbContext.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return myStoreDbContext.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return myStoreDbContext.Categories.ToList().Find(x => x.CategoryId == id);
        }

        public void AddCategory(Category category)
        {
            myStoreDbContext.Categories.Add(category);
            Save();
        }

        public void DeleteCategory(int id)
        {
            myStoreDbContext.Categories.Remove(GetCategoryById(id));
            Save();
        }

        public void UpdateCategory(Category category)
        {
            myStoreDbContext.Categories.Update(category);
            Save();
        }
    }
}
