using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vsporte.HandlerServices.BaseEntityCRUDStrategy;
using VSporte.HelpEnums.BaseCRUDManipulation;

namespace Vsporte.HandlerServices.Services.Handlers.BaseEntityCRUDStrategyFactory
{
    /// <summary>
    /// Интерфейс используемый в фабрике для построения нужной стратегии
    /// </summary>
    public interface IBaseCrudStrategyFactory
    {
        /// <summary>
        /// Создание стратегии
        /// </summary>
        /// <param name="strategyId">Идентитификатор стратегии</param>
        IBaseCrudStrategy CreateStrategy(StrategyChangeEnum strategyId);
    }
}
