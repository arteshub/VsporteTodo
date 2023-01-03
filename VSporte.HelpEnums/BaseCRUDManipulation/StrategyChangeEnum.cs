using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSporte.HelpEnums.BaseCRUDManipulation
{
    /// <summary>
    /// Enum для описания стратегий 
    /// CRUD операций для сущностей
    /// </summary>
    public enum StrategyChangeEnum
    {
        ClubItemStrategy = 1, 
        PlayerClubItemStrategy = 2, 
        PlayerItemStrategy = 3, 
        GameEventStrategy = 4 
    }
}
