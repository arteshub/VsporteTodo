using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vsporte.HandlerServices.BaseEntityCRUDStrategy;
using VSporte.HelpEnums.BaseCRUDManipulation;

namespace Vsporte.HandlerServices.Services.Handlers.BaseEntityCRUDStrategyFactory
{
    public interface IBaseCrudStrategyFactory
    {
        IBaseCrudStrategy CreateStrategy(StrategyChangeEnum strategyId);
    }
}
