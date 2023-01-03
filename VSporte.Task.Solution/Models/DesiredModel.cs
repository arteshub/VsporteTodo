using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSporte.DataAccessLayer.Models
{
    /// <summary>
    /// Универсальная модель для универсальных CRUD операций
    /// передающаяся в контроллеры в качестве параметра
    /// </summary>
    public class DesiredModel
    {
        public int? ClubId { get; set; } // идентификатор клуба
        public string? FullName { get; set; } = string.Empty; // полное именоване
        public string? City { get; set; } = string.Empty;  // город 
        public string? VsporteDescription { get; set; } = string.Empty;  // внутренний комментарий Вспорте
        public int? SystemId { get; set; } // системная идентификация 
        public int? PlayerId { get; set; } // идентификатор игрока
        public string? Surname { get; set; } = string.Empty;  // фамилия игрока
        public string? Name { get; set; } = string.Empty;  // имя игрока
        public string? Number { get; set; } = string.Empty;  // номер игрока
        public string? ShortName { get; set; } = string.Empty;  // краткое именование сущности
        public string? EventType { get; set; } = string.Empty;  // тип события
        public DateTime? TimeOfEvent { get; set; } // время в которое произошло событие
    }
}
