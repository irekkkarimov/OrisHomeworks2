using MediatR;
using Microsoft.AspNetCore.Identity;
using TeamHost.Application.DTOs.User;

namespace TeamHost.Application.Features.Users.Commands;

public class UserRegisterCommand : IRequest<bool>
{
    public UserRegisterCommand(UserRegisterDto request)
    {
        Request = request;
    }

    public UserRegisterDto Request { get; set; }
}

internal class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, bool>
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public UserRegisterCommandHandler(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<bool> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
    {
        var newIdentityUser = new IdentityUser
        {
            UserName = request.Request.Username,
            Email = request.Request.Email
        };

        var result = await _signInManager.UserManager.CreateAsync(newIdentityUser, request.Request.Password);

        if (!result.Errors.Any())
            return result.Succeeded;

        foreach (var error in result.Errors)
        {
            Console.WriteLine(error.Description);
        }

        return result.Succeeded;
    }
}