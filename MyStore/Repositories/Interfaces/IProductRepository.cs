using MyStore.Models;

namespace MyStore.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product category);
        void DeleteProduct(int id);
        void UpdateProduct(Product category);

    }
}
