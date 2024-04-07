using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamHost.Application.Features.Users.Queries;

namespace TeamHostApp.WEB.Controllers;

[Authorize]
public class ProfileController : Controller
{
    private readonly IMediator _mediator;

    public ProfileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var getUserInfoQuery = new GetUserInfoQuery();
        var userInfo = await _mediator.Send(getUserInfoQuery);
        return View(userInfo);
    }
}