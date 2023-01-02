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
    public class BaseCrudStrategyFactory : IBaseCrudStrategyFactory
    {
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
