using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VSporte.DataAccessLayer.Models;
using VSporte.DataAccessLayer.Models.Interfaces;

namespace VSporte.Task.Solution.Models;

public class PlayerItem : IBaseEntity
{
    [Key]
    public int PlayerId { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Number { get; set; }
    public string? VsporteDescription { get; set; }

    // для внешних ключиков
    public virtual ICollection<GameEvent> GameEvents { get; set; }
    public virtual ICollection<PlayerClubItem> PlayerClubItems { get; set; }
}