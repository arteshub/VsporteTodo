using System.ComponentModel.DataAnnotations;
using VSporte.DataAccessLayer.Models.Interfaces;

namespace VSporte.Task.Solution.Models;

public class PlayerClubItem : IBaseEntity
{
    [Key]
    public int SystemId { get; set; }
    public int PlayerId { get; set; }
    public int ClubId { get; set; }
    public string? VsporteDescription { get; set; }

    // внешние ключики  
    public ClubItem Club { get; set; }
    public PlayerItem Player { get; set; }

}