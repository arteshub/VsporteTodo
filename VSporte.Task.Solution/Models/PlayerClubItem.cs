using System.ComponentModel.DataAnnotations;
using VSporte.DataAccessLayer.Models.Interfaces;

namespace VSporte.Task.Solution.Models;

/// <summary>
/// Модель, описывающая сущность для связи игрока и клуба
/// </summary>
public class PlayerClubItem : IBaseEntity
{
    [Key]
    public int SystemId { get; set; } // системный идентификатор
    public int PlayerId { get; set; } // идентификатор игрока
    public int ClubId { get; set; } // идентификатор клуба
    public string? VsporteDescription { get; set; } = string.Empty;  // внутреннее описание Вспорте

    // свойства для установки внешних ключей 
    public ClubItem Club { get; set; }
    public PlayerItem Player { get; set; }

}