using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSporte.HelpEnums.BaseCRUDManipulation
{
    /// <summary>
    /// Enum для описания всвозможных стратегий
    /// </summary>
    public enum StrategyChangeEnum
    {
        ClubItemStrategy = 1, // создаст ClubItemStrategy
        PlayerClubItemStrategy = 2, // создаст PlayerClubItemStrategy
        PlayerItemStrategy = 3, // создаст PlayerItemStrategy
        GameEventStrategy = 4 // создаст GameEventStrategy
    }
}
