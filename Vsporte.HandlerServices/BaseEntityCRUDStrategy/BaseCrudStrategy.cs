using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSporte.DataAccessLayer.Models.Interfaces;
using VSporte.HelpEnums;

namespace Vsporte.HandlerServices.BaseEntityCRUDStrategy
{
    internal class BaseCrudStrategy 
    {
       private IBaseCrudStrategy? _baseCrudStrategy;

       public void SetStrategy(IBaseCrudStrategy baseCrudStrategy)
       {
           _baseCrudStrategy = baseCrudStrategy;    
       }

       public Task<IBaseEntity> GetByID(int id) // применение стратегии поиска по идентификатору
       {
           Error(_baseCrudStrategy);
           return _baseCrudStrategy.GetByID(id);
           
       }

       public async Task AddEntity(IBaseEntity entity)
       {
           Error(_baseCrudStrategy);
           await _baseCrudStrategy.AddEntity(entity);
       }
       public async Task UpdateEntity(int id, IBaseEntity entity)
       {
           Error(_baseCrudStrategy);
           await _baseCrudStrategy.UpdateEntity(id, entity);
       }

        public async Task DeleteEntity(int id)
       {
           Error(_baseCrudStrategy);
           await _baseCrudStrategy.DeleteEntity(id);
       }

        /// <summary>
        /// метод, проверяющий наличие стратегии
        /// </summary>
        /// <param name="_baseCrudStrategy"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Error(IBaseCrudStrategy? _baseCrudStrategy)
        {
            if (_baseCrudStrategy is null) throw new NotImplementedException("Контекст сущности не найден");
        }

    }
}
