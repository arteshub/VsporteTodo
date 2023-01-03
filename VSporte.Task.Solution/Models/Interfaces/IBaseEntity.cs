using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VSporte.DataAccessLayer.Models.Interfaces
{
    public interface IBaseEntity
    {
        /// <summary>
        /// Базовый интерфейс, описывающий сущности, связанный с Vsporte
        /// для связывание всех сущностей в одном месте, при использование CRUD операций
        /// </summary>
        public string? VsporteDescription { get; set; }
    }
}
