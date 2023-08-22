using MyStore.Models;

namespace MyStore.Repositories.Interfaces
{
	public interface ICategoryRepository
	{
		IEnumerable<Category> GetAllCategories();
		Category GetCategoryById(int id);
		void AddCategory(Category category);
		void DeleteCategory(int id);
		void UpdateCategory(Category category);

	}
}
