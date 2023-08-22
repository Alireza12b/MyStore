using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using MyStore.Repositories.Interfaces;
using MyStore.Repositories.Services;

namespace MyStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;

        public ProductsController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        { 
            return View(productRepository.GetAllProducts());
        }

        public IActionResult Create()
        {
            var viewmodel = new AddViewModel();
            viewmodel.categories = categoryRepository.GetAllCategories();
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product category)
        {
            productRepository.AddProduct(category);
            return RedirectToAction("Index");
        }
    }
}
