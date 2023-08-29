using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using MyStore.Repositories.Interfaces;
using MyStore.Repositories.Services;

namespace MyStore.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly UserManager<MyStoreUser> userManager;
        public ProductsController(IProductRepository productRepository, ICategoryRepository categoryRepository, UserManager<MyStoreUser> userManager)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.userManager = userManager;
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
        public async Task<IActionResult> Create(AddViewModel productVm)
        {
            var user = await userManager.GetUserAsync(User);
            productVm.Category = categoryRepository.GetAllCategories().FirstOrDefault(x => x.CategoryId == productVm.CategoryId);
            var product = new Product()
            {
                Name = productVm.Name,
                Price = productVm.Price,
                ManufactureDate = productVm.ManufactureDate,
                Category = productVm.Category,
                CategoryId = productVm.Category.CategoryId,
                MyStoreUser = user,
                MyStoreUserId = user.Id,
            };
            productRepository.AddProduct(product);
            return RedirectToAction("Index");
        }
    }
}
