using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vsporte.HandlerServices.BaseEntityCRUDStrategy.Strategies;
using Vsporte.HandlerServices.BaseEntityCRUDStrategy;
using VSporte.HelpEnums.BaseCRUDManipulation;

namespace Vsporte.HandlerServices.Services.Handlers.BaseEntityCRUDStrategyFactory
{
    /// <summary>
    /// Класс - фабрика для создания еужной стратегии
    /// в зависимости от входного параметра контроллера
    /// </summary>
    public class BaseCrudStrategyFactory : IBaseCrudStrategyFactory
    {
        /// <summary>
        /// Метод строящий нужную стратегию
        /// для базовых сущностей
        /// </summary>
        /// <param name="strategyId"></param>
        /// <returns>Стратегия для выбранной сущности</returns>
        public IBaseCrudStrategy CreateStrategy(StrategyChangeEnum strategyId)
        {
            switch (strategyId)
            {
                case StrategyChangeEnum.ClubItemStrategy:
                    return new ClubItemStrategy();
                case StrategyChangeEnum.PlayerClubItemStrategy:
                    return new PlayerClubItemStrategy();
                case StrategyChangeEnum.PlayerItemStrategy:
                    return new PlayerItemStrategy();
                case StrategyChangeEnum.GameEventStrategy:
                    return new GameEventStrategy();
                default:
                    throw new ArgumentException("Неизвестный идентификатор стратегии", nameof(strategyId));
            }
        }
    }
}
