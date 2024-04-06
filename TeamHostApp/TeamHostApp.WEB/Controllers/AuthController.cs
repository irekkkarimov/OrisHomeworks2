using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.DTOs.User;
using TeamHost.Application.Features.Users.Commands;

namespace TeamHostApp.WEB.Controllers;

public class AuthController : Controller
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    public async Task<IActionResult> LoginAsync([FromForm] UserLoginDto userLoginDto)
    {
        if (!ModelState.IsValid)
            return View();

        var userLoginCommand = new UserLoginCommand(userLoginDto);
        var result = await _mediator.Send(userLoginCommand);

        if (result)
            return RedirectToAction("Index", "Home");

        return View();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> RegisterAsync([FromForm] UserRegisterDto userRegisterDto)
    {
        if (!ModelState.IsValid)
            return View();
        
        var userRegisterCommand = new UserRegisterCommand(userRegisterDto);
        var result = await _mediator.Send(userRegisterCommand);
        return Ok(result);
    }

    public async Task<IActionResult> Logout()
    {
        var userLogoutCommand = new UserLogoutCommand();
        await _mediator.Send(userLogoutCommand);
        return RedirectToAction("Index", "Home");
    }
}