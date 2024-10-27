using Microsoft.AspNetCore.Mvc;

namespace Site.Controllers;

public class authController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}