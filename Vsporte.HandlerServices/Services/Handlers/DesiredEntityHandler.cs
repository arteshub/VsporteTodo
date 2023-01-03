using VSporte.DataAccessLayer.Models.Interfaces;
using VSporte.DataAccessLayer.Models;
using VSporte.HelpEnums.BaseCRUDManipulation;
using VSporte.Task.Solution.Models;
using AutoMapper;

namespace Vsporte.HandlerServices.Services.Handlers
{
    public static class DesiredEntityHandler
    {
        /// <summary>
        /// Маппит универсальную сущность в ту, которая должна использоваться 
        /// для создания определенной стратегии
        /// </summary>
        /// <param name="item"></param>
        /// <param name="strategyId"></param>
        /// <returns></returns>
        public static IBaseEntity GetDesiredEntity(this StrategyChangeEnum strategyId, DesiredModel? item = null)
        {
            IBaseEntity entity = null;
            MapperConfiguration config = null;
            switch (strategyId)
            {
                case StrategyChangeEnum.ClubItemStrategy:
                    config = GetConfiguration(typeof(DesiredModel), typeof(ClubItem));
                    entity = config.CreateMapper().Map<ClubItem>(item);
                    break;
                case StrategyChangeEnum.PlayerClubItemStrategy:
                    config = GetConfiguration(typeof(DesiredModel), typeof(PlayerClubItem));
                    entity = config.CreateMapper().Map<PlayerClubItem>(item);
                    break;
                case StrategyChangeEnum.PlayerItemStrategy:
                    config = GetConfiguration(typeof(DesiredModel), typeof(PlayerItem));
                    entity = config.CreateMapper().Map<PlayerItem>(item);
                    break;
                case StrategyChangeEnum.GameEventStrategy:
                    config = GetConfiguration(typeof(DesiredModel), typeof(GameEvent));
                    entity = config.CreateMapper().Map<GameEvent>(item);
                    break;
            }
            return entity;
        }

        /// <summary>
        /// логика создания конфига для маппера
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        private static MapperConfiguration GetConfiguration(Type sourceType, Type destinationType)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap(sourceType, destinationType);
            });
        }
    }
}
