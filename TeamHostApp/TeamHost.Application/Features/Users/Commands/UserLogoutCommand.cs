using MediatR;
using Microsoft.AspNetCore.Identity;
using TeamHost.Domain.Entities.User;

namespace TeamHost.Application.Features.Users.Commands;

public class UserLogoutCommand : IRequest
{
}

internal class UserLogoutCommandHandler : IRequestHandler<UserLogoutCommand>
{
    private readonly SignInManager<User> _signInManager;

    public UserLogoutCommandHandler(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task Handle(UserLogoutCommand request, CancellationToken cancellationToken)
    {
        await _signInManager.SignOutAsync();
    }
}