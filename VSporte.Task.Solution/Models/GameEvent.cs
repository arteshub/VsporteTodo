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
    /// <summary>
    /// Модель, описывающая сущность игрового события
    /// </summary>
    public class GameEvent : IBaseEntity
    {
        [Key]
        public int EventId { get; set; } // идентификатор события
        public int PlayerId { get; set; } // идентификатор игрока
        public int ClubId { get; set; } // идентификатор клуба
        public string? EventType { get; set; } = string.Empty;  // тип игрового события
        public string? VsporteDescription { get; set; } = string.Empty;  // внутренний комментарий Вспорте
        public DateTime? TimeOfEvent { get; set; } // время в которое произошло событие

        // свойства для установки внешних ключей
        public virtual ClubItem Club { get; set; }
        public virtual PlayerItem Player { get; set; }

    }
}
