using Microsoft.AspNetCore.Mvc;
using TeamHost.Application.Interfaces.Repositories;
using TeamHost.Domain.Entities.GameEntities;

namespace TeamHostApp.WEB.Controllers;

public class GameProfileController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}