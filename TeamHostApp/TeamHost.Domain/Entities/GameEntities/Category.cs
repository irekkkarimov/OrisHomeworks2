using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities.GameEntities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public List<Game> Games { get; set; }
}