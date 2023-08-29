using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using MyStore.Repositories.Interfaces;

namespace MyStore.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var allCats = categoryRepository.GetAllCategories();
            return View(allCats);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            categoryRepository.AddCategory(category);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            categoryRepository.DeleteCategory(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(categoryRepository.GetCategoryById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            categoryRepository.UpdateCategory(category);
            return RedirectToAction("Index");
        }
    }
}
