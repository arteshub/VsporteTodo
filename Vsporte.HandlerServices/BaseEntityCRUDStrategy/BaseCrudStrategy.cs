using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSporte.DataAccessLayer.Models.Interfaces;
using VSporte.HelpEnums;

namespace Vsporte.HandlerServices.BaseEntityCRUDStrategy
{
    /// <summary>
    /// Класс устанавливающий необходимую стратегии
    /// </summary>
    internal class BaseCrudStrategy 
    {
       private IBaseCrudStrategy? _baseCrudStrategy;

        /// <summary>
        /// Метод определения стратегии
        /// </summary>
        public void SetStrategy(IBaseCrudStrategy baseCrudStrategy)
       {
           _baseCrudStrategy = baseCrudStrategy;    
       }

        /// <summary>
        /// Базовый метод поиска по идентификатору
        /// </summary> 
        public Task<IBaseEntity> GetByID(int id) // применение стратегии поиска по идентификатору
       {
           Error(_baseCrudStrategy);
           return _baseCrudStrategy.GetByID(id);
           
       }

        /// <summary>
        /// Базовый метод добавления сущности в БД
        /// </summary> 
        public async Task AddEntity(IBaseEntity entity)
       {
           Error(_baseCrudStrategy);
           await _baseCrudStrategy.AddEntity(entity);
       }

        /// <summary>
        /// Базовый метод обновления сущности в БД
        /// </summary> 
        public async Task UpdateEntity(int id, IBaseEntity entity)
       {
           Error(_baseCrudStrategy);
           await _baseCrudStrategy.UpdateEntity(id, entity);
       }

       /// <summary>
       /// Базовый метод удаления сущности из БД
       /// </summary> 
        public async Task DeleteEntity(int id)
       {
           Error(_baseCrudStrategy);
           await _baseCrudStrategy.DeleteEntity(id);
       }

        /// <summary>
        /// метод, проверяющий наличие стратегии
        /// </summary>
        /// <param name="_baseCrudStrategy">Сущность стратегии</param>
        public void Error(IBaseCrudStrategy? _baseCrudStrategy)
        {
            if (_baseCrudStrategy is null) throw new ArgumentException("Контекст сущности не найден");
        }

    }
}
