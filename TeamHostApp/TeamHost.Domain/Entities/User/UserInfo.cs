using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;
using TeamHost.Domain.Common;
using TeamHost.Domain.Entities.GameEntities;

namespace TeamHost.Domain.Entities.User;

public class UserInfo : BaseAuditableEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Bio { get; set; }
    public int CountryId { get; set; }
    public Country? Country { get; set; }
    public DateTime? BirthDate { get; set; }
    
}