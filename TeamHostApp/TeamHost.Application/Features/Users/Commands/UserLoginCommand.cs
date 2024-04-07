using MediatR;
using Microsoft.AspNetCore.Identity;
using TeamHost.Application.DTOs.User;
using TeamHost.Application.Interfaces.Repositories;
using TeamHost.Domain.Entities.User;

namespace TeamHost.Application.Features.Users.Commands;

public class UserLoginCommand : IRequest<bool>
{
    public UserLoginCommand(UserLoginDto request)
    {
        Request = request;
    }

    public UserLoginDto Request { get; set; }
}

internal class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, bool>
{
    private readonly SignInManager<User> _signInManager;

    public UserLoginCommandHandler(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<bool> Handle(UserLoginCommand command, CancellationToken cancellationToken)
    {
        var userByEmail = await _signInManager.UserManager.FindByEmailAsync(command.Request.Email);

        if (userByEmail is null)
            throw new ArgumentException("User by given email not found");

        var isPasswordCorrect =
            await _signInManager.PasswordSignInAsync(userByEmail, command.Request.Password, true, false);

        return isPasswordCorrect.Succeeded;
    }
}