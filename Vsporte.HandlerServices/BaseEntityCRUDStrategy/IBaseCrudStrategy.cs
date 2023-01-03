using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VSporte.DataAccessLayer.Models.Interfaces;

namespace Vsporte.HandlerServices.BaseEntityCRUDStrategy
{
    public interface IBaseCrudStrategy
    {
        public Task<IBaseEntity> GetByID(int id);
        public Task AddEntity (IBaseEntity entity);
        public Task UpdateEntity(int id, IBaseEntity entity);
        public Task DeleteEntity(int id);

    }
}
