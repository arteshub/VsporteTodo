using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VSporte.DataAccessLayer.Models;
using VSporte.DataAccessLayer.Models.Interfaces;

namespace VSporte.Task.Solution.Models;

    /// <summary>
    /// ћодель, описывающа€ сущность клуба
    /// </summary>
    public class ClubItem: IBaseEntity
    {
        [Key]
        public int ClubId { get; set; } // идентификатор клуба
        public string FullName { get; set; } = string.Empty; // полное название
        public string? City { get; set; } = string.Empty; // город клуба
        public string? VsporteDescription { get; set; } = string.Empty; // примечание Vsporte
        public string? ShortName { get; set; } = string.Empty; // краткое именование

        // свойства дл€ установки внешних ключей
        public virtual ICollection<GameEvent> GameEvents { get; set; }
        public virtual ICollection<PlayerClubItem> PlayerClubItems { get; set; }
    }