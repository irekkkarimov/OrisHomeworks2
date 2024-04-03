using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities.GameEntities;

public class Country : BaseEntity
{
    /// <summary>
    /// Название страны
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Код страны
    /// </summary>
    public int Code { get; set; }
    
    /// <summary>
    /// 2-х буквенный код страны
    /// </summary>
    [MaxLength(2)]
    public string Alpha2 { get; set; }
    
    /// <summary>
    /// 3-х буквенный код страны
    /// </summary>
    [MaxLength(3)]
    public string Alpha3 { get; set; }
    
    [NotMapped]
    public List<Company> Developers { get; set; }
}