using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VSporte.DataAccessLayer.DbContextBase;
using VSporte.DataAccessLayer.Models.Interfaces;
using VSporte.Task.Solution.Models;

namespace Vsporte.HandlerServices.BaseEntityCRUDStrategy.Strategies
{
    /// <summary>
    /// Реализация стратегии CRUD операций для ClubItem
    /// </summary>
    public class PlayerClubItemStrategy : IBaseCrudStrategy
    {
        private readonly DataContext _context = new DataContext(); // контекст базы данных

        Task<IBaseEntity> IBaseCrudStrategy.GetByID(int id) // рисуем красивую ассинхронность для использовании в контроллере
        {
            using (_context)
            {
                PlayerClubItem? playerClub = _context.PlayerClubItems.ToList().Find(c => c.SystemId == id); // поиск сущности клуба по ее идентификатору
                return Task.FromResult<IBaseEntity>(playerClub);
            }
        }

        async Task IBaseCrudStrategy.AddEntity(IBaseEntity playerClub) // добавление сущности клуба в БД c помощью стратегии
        {
            using (_context)
            {
                await _context.PlayerClubItems.AddAsync((PlayerClubItem)playerClub);
                await _context.SaveChangesAsync();
            }
        }

        async Task IBaseCrudStrategy.UpdateEntity(int id, IBaseEntity entity) // обновление сущности клуба в БД
        {
            using (_context)
            {
                var playerClub = _context.PlayerClubItems.FirstOrDefault(c => c.SystemId == id);

                var iBaseEntity = (PlayerClubItem)entity; // приводим тип к нужному

                // Если сущность найдена, то обновляем ее значения
                if (playerClub != null)
                {
                    playerClub.ClubId = iBaseEntity.ClubId;
                    playerClub.PlayerId = iBaseEntity.PlayerId;
                    playerClub.VsporteDescription = iBaseEntity.VsporteDescription;

                    // Сохраняем изменения в базу данных
                    await _context.SaveChangesAsync();
                }
            }
        }

        async Task IBaseCrudStrategy.DeleteEntity(int id) // обновление сущности клуба в БД
        {
            using (_context)
            {
                var playerClub = _context.PlayerClubItems.FirstOrDefault(c => c.ClubId == id);

                // Если сущность найдена, то удаляем ее
                if (playerClub != null)
                {
                    _context.Remove(playerClub);

                    // Сохраняем изменения в базу данных
                    await _context.SaveChangesAsync();
                }
            }
        }

    }
}

