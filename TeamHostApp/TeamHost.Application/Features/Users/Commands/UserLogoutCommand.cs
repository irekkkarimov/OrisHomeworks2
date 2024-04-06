using MediatR;
using Microsoft.AspNetCore.Identity;

namespace TeamHost.Application.Features.Users.Commands;

public class UserLogoutCommand : IRequest
{
}

internal class UserLogoutCommandHandler : IRequestHandler<UserLogoutCommand>
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public UserLogoutCommandHandler(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task Handle(UserLogoutCommand request, CancellationToken cancellationToken)
    {
        await _signInManager.SignOutAsync();
    }
}