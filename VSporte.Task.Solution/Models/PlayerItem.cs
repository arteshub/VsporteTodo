using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VSporte.DataAccessLayer.Models;
using VSporte.DataAccessLayer.Models.Interfaces;

namespace VSporte.Task.Solution.Models;

/// <summary>
/// Модель, описывающая сущность игрока
/// </summary>
public class PlayerItem : IBaseEntity
{
    [Key]
    public int PlayerId { get; set; } // идентификатор игрока
    public string Surname { get; set; } = string.Empty; // отчество игрока
    public string Name { get; set; } = string.Empty; // имя игрока
    public string Number { get; set; } = string.Empty; // номер игрока
    public string? VsporteDescription { get; set; } = string.Empty; // комментарий Вспорте

    // свойства для установки внешних ключей
    public virtual ICollection<GameEvent> GameEvents { get; set; }
    public virtual ICollection<PlayerClubItem> PlayerClubItems { get; set; }
}