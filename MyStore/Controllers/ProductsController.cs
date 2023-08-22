using Microsoft.AspNetCore.Mvc;

namespace MyStore.Controllers
{
    public class ProductsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
