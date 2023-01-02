using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSporte.DataAccessLayer.Models.Interfaces;
using VSporte.Task.Solution.Models;

namespace VSporte.DataAccessLayer.Models
{
    public class GameEvent : IBaseEntity
    {
        [Key]
        public int EventId { get; set; }
        public int PlayerId { get; set; }
        public int ClubId { get; set; }
        public string? EventType { get; set; }
        public string? VsporteDescription { get; set; }
        public DateTime? TimeOfEvent { get; set; }

        // внешние ключики
        public virtual ClubItem Club { get; set; }
        public virtual PlayerItem Player { get; set; }

    }
}
