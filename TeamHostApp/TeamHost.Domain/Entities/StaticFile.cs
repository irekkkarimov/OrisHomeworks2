using TeamHost.Domain.Common;
using TeamHost.Domain.Entities.GameEntities;

namespace TeamHost.Domain.Entities;

public class StaticFile : BaseAuditableEntity
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="path">Путь</param>
    /// <param name="name">Имя</param>
    public StaticFile(string path, string name)
    {
        Path = path;
        Name = name;
        Extension = name.Split('.').LastOrDefault();
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    private StaticFile()
    {
    }
    
    /// <summary>
    /// Путь
    /// </summary>
    public string Path { get; set; }

    /// <summary>
    /// Размер в КБ
    /// </summary>
    public int? Size { get; set; }

    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; }

    public bool IsMainImage { get; set; } = false;

    /// <summary>
    /// Расширение
    /// </summary>
    public string? Extension { get; private set; }
}