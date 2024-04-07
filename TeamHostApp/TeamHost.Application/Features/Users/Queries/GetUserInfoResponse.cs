using TeamHost.Domain.Entities.GameEntities;

namespace TeamHost.Application.Features.Users.Queries;

public class GetUserInfoResponse
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Bio { get; set; }
    public Country Country { get; set; } = null!;
    public DateTime BirthDate { get; set; }
}