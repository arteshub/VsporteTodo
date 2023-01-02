using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSporte.DataAccessLayer.Models.Interfaces;
using Vsporte.HandlerServices.BaseEntityCRUDStrategy;
using Vsporte.HandlerServices.BaseEntityCRUDStrategy.Strategies;
using VSporte.Task.Solution.Models;
using VSporte.HelpEnums;

namespace Vsporte.HandlerServices.Services.Handlers
{
    /// <summary>
    /// Класс описывающий базовый CRUD функционал для взаимодействия
    /// со сущностями IBaseEntity
    /// </summary>
    public class BaseManipulationOperationsHandler
    {
        private readonly BaseCrudStrategy _baseCrudStrategy = new BaseCrudStrategy();

        public async Task<IBaseEntity> GetEntitiesById(int id, IBaseCrudStrategy crudStrategy)
        {
            _baseCrudStrategy.SetStrategy(crudStrategy);
            return await _baseCrudStrategy.GetByID(id);
        } // применение стратегии поиска по идентификатору

        public async Task AddEntity(IBaseEntity entity, IBaseCrudStrategy crudStrategy)
        {
            _baseCrudStrategy.SetStrategy(crudStrategy);
            await _baseCrudStrategy.AddEntity(entity);
        } // применение стратегии добавления сущности

        public async Task UpdateEntity(int id, IBaseEntity entity, IBaseCrudStrategy crudStrategy)
        {
            _baseCrudStrategy.SetStrategy(crudStrategy);
            await _baseCrudStrategy.UpdateEntity(id, entity);
        } // применение стратегии обновления сущности

        public async Task DeleteEntity(int id, IBaseCrudStrategy crudStrategy)
        {
            _baseCrudStrategy.SetStrategy(crudStrategy);
            await _baseCrudStrategy.DeleteEntity(id);
        } // применение стратегии удаления сущности

    }
}
