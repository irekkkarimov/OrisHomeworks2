using Microsoft.AspNetCore.Mvc;

namespace TeamHostApp.WEB.Controllers;

public class ProfileController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}