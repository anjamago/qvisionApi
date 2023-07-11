using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class AutoresController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}