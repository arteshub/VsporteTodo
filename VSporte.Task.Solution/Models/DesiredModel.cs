using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSporte.DataAccessLayer.Models
{
    /// <summary>
    /// Универсальная модель для универсальных CRUD операций
    /// </summary>
    public class DesiredModel
    {
        public int? ClubId { get; set; }
        public string? FullName { get; set; } = string.Empty;
        public string? City { get; set; }
        public string? VsporteDescription { get; set; }
        public int? SystemId { get; set; }
        public int? PlayerId { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? ShortName { get; set; }
        public string? EventType { get; set; }
        public DateTime? TimeOfEvent { get; set; }
    }
}
