using MediatR;
using Microsoft.AspNetCore.Identity;
using TeamHost.Application.DTOs.User;
using TeamHost.Application.Interfaces.Repositories;
using TeamHost.Domain.Entities.User;

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
    private readonly SignInManager<User> _signInManager;
    private readonly IGenericRepository<UserInfo> _userInfoRepository;

    public UserRegisterCommandHandler(SignInManager<User> signInManager,
        IGenericRepository<UserInfo> userInfoRepository)
    {
        _signInManager = signInManager;
        _userInfoRepository = userInfoRepository;
    }

    public async Task<bool> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
    {
        var newUser = new User
        {
            UserName = request.Request.Username,
            Email = request.Request.Email
        };

        var result = await _signInManager.UserManager.CreateAsync(newUser, request.Request.Password);

        foreach (var error in result.Errors)
        {
            Console.WriteLine(error.Description);
        }
        
        return result.Succeeded;
    }
}