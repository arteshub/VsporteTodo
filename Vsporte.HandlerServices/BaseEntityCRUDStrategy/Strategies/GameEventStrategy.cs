using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vsporte.HandlerServices.Services.Handlers;
using VSporte.DataAccessLayer.DbContextBase;
using VSporte.DataAccessLayer.Models;
using VSporte.DataAccessLayer.Models.Interfaces;
using VSporte.Task.Solution.Models;

namespace Vsporte.HandlerServices.BaseEntityCRUDStrategy.Strategies
{
    /// <summary>
    /// Реализация стратегии CRUD операций для GameEvent
    /// </summary>
    public class GameEventStrategy : IBaseCrudStrategy
    {
        private readonly DataContext _context = new DataContext(); // контекст базы данных

        Task<IBaseEntity> IBaseCrudStrategy.GetByID(int id) // рисуем красивую ассинхронность для использовании в контроллере
        {
            using (_context)
            {
                GameEvent? gameEvent = _context.GameEvents.ToList().Find(c => c.EventId == id); // поиск сущности события по ее идентификатору
                return Task.FromResult<IBaseEntity>(gameEvent);
            }
        }

        async Task IBaseCrudStrategy.AddEntity(IBaseEntity gameEventItem) // добавление сущности события в БД c помощью стратегии
        {
            using (_context)
            {
                await _context.GameEvents.AddAsync((GameEvent)gameEventItem);
                await _context.SaveChangesAsync();
            }
        }

        async Task IBaseCrudStrategy.UpdateEntity(int id, IBaseEntity entity) // обновление сущности события в БД
        {
            using (_context)
            {
                var gameEventEntity = _context.GameEvents.FirstOrDefault(c => c.EventId == id);

                var iBaseEntity = (GameEvent)entity; // приводим тип к нужному

                // Если сущность найдена, то обновляем ее значения
                if (gameEventEntity != null)
                {
                    gameEventEntity.PlayerId = iBaseEntity.PlayerId;
                    gameEventEntity.ClubId = iBaseEntity.ClubId;
                    gameEventEntity.VsporteDescription = iBaseEntity.VsporteDescription;
                    gameEventEntity.EventType = iBaseEntity.EventType;
                    gameEventEntity.TimeOfEvent = iBaseEntity.TimeOfEvent;

                    // Сохраняем изменения в базу данных
                    await _context.SaveChangesAsync();
                }
            }
        }

        async Task IBaseCrudStrategy.DeleteEntity(int id) // обновление сущности клуба в БД
        {
            using (_context)
            {
                var gameEventEntity = _context.GameEvents.FirstOrDefault(c => c.ClubId == id);

                // Если сущность найдена, то удаляем ее
                if (gameEventEntity != null)
                {
                    _context.Remove(gameEventEntity);

                    // Сохраняем изменения в базу данных
                    await _context.SaveChangesAsync();
                }
            }
        }

    }
}

