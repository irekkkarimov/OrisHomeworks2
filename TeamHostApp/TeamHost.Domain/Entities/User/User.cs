using Microsoft.AspNetCore.Identity;

namespace TeamHost.Domain.Entities.User;

public class User : IdentityUser<Guid>
{
    public UserInfo? UserInfo { get; set; }
}