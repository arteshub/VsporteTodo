using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VSporte.DataAccessLayer.Models.Interfaces;
using Vsporte.HandlerServices.BaseEntityCRUDStrategy.Strategies;
using VSporte.Task.Solution.Models;
using Vsporte.HandlerServices.Services.Handlers;
using VSporte.HelpEnums.BaseCRUDManipulation;
using AutoMapper;
using VSporte.DataAccessLayer.Models;
using Vsporte.HandlerServices.BaseEntityCRUDStrategy;

namespace Vsporte.BaseManipulationsWebApi.Controllers.ClubItemControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCRUDManipulationController : ControllerBase
    {
        private readonly BaseManipulationOperationsHandler _baseManipulationOperationsHandler = new BaseManipulationOperationsHandler();

        #region CRUDOperations

        /// <summary>
        /// получение сущности по ее идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        /// <returns>Искомая сущность</returns>
        [HttpGet]
        public async Task<ActionResult<IBaseEntity>> GetItemByID(int id, StrategyChangeEnum strategyId)
        {
            var requiredStrategy = strategyId.StrategyChanger();
            try
            {
                var clubEntitie = await _baseManipulationOperationsHandler.GetEntitiesById(id, requiredStrategy);
                return Ok(clubEntitie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// создание новой сущности
        /// </summary>
        /// <param name="item">Обобщенная модель</param>
        [HttpPost]
        public async Task AddItemAsync(DesiredModel item, StrategyChangeEnum strategyId)
        {
            // маппинг нужной модельки из обобщенной
            IBaseEntity entity = strategyId.GetDesiredEntity(item);
            var requiredStrategy = strategyId.StrategyChanger();
            await _baseManipulationOperationsHandler.AddEntity(entity, requiredStrategy);
        }

        /// <summary>
        /// редактирование существующей сущности
        /// </summary>
        /// <param name="item">Обобщенная модель</param>
        /// <param name="id">Идентитификатор сущности</param>
        [HttpPut]
        public async Task UpdateItemAsync(DesiredModel item, int id, StrategyChangeEnum strategyId)
        {
            // маппинг нужной модельки из обобщенной
            IBaseEntity entity = strategyId.GetDesiredEntity(item);
            var requiredStrategy = strategyId.StrategyChanger();
            await _baseManipulationOperationsHandler.UpdateEntity(id, entity, requiredStrategy);
        }

        /// <summary>
        /// редактирование существующей сущности
        /// </summary>
        /// <param name="id">Идентитификатор сущности   </param>
        [HttpDelete]
        public async Task DeleteItem(int id, StrategyChangeEnum strategyId)
        {
            var requiredStrategy = strategyId.StrategyChanger();
            await _baseManipulationOperationsHandler.DeleteEntity(id, requiredStrategy);
        }

        #endregion

    }
}
