using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vsporte.HandlerServices.BaseEntityCRUDStrategy;
using Vsporte.HandlerServices.BaseEntityCRUDStrategy.Strategies;
using Vsporte.HandlerServices.Services.Handlers.BaseEntityCRUDStrategyFactory;
using VSporte.HelpEnums.BaseCRUDManipulation;

namespace Vsporte.HandlerServices.Services.Handlers
{
    public static class BaseEntityCRUDStrategyBuilder
    {
        private static readonly IBaseCrudStrategyFactory Factory = new BaseCrudStrategyFactory();

        public static IBaseCrudStrategy StrategyChanger(this StrategyChangeEnum strategyId)
        {
            return Factory.CreateStrategy(strategyId);
        }
    }
}
