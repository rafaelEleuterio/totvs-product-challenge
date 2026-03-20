using Microsoft.AspNetCore.Mvc;

namespace ProducManager.Api.Controllers;
public class ProductsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
