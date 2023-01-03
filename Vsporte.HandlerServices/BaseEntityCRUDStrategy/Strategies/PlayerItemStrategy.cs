using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Vsporte.HandlerServices.Services.Handlers;
using VSporte.DataAccessLayer.DbContextBase;
using VSporte.DataAccessLayer.Models.Interfaces;
using VSporte.Task.Solution.Models;

namespace Vsporte.HandlerServices.BaseEntityCRUDStrategy.Strategies
{

    /// <summary>
    /// Реализация стратегии CRUD операций для ClubItem
    /// </summary>
    public class PlayerItemStrategy : IBaseCrudStrategy
    {
        private readonly DataContext _context = new DataContext(); // контекст базы данных
        #region CRUDOperations
        Task<IBaseEntity> IBaseCrudStrategy.GetByID(int id) // рисуем красивую ассинхронность для использовании в контроллере
        {
            using (_context)
            {
                PlayerItem? player = _context.PlayerItems.ToList().Find(c => c.PlayerId == id); // поиск сущности игрока по ее идентификатору
                return Task.FromResult<IBaseEntity>(player);
            }
        }

        async Task IBaseCrudStrategy.AddEntity(IBaseEntity player) // добавление сущности клуба в БД c помощью стратегии
        {
            using (_context)
            {
                await _context.PlayerItems.AddAsync((PlayerItem)player);
                await _context.SaveChangesAsync();
            }
        }

        async Task IBaseCrudStrategy.UpdateEntity(int id, IBaseEntity entity) // обновление сущности клуба в БД
        {
            using (_context)
            {
                var playerEntity = _context.PlayerItems.FirstOrDefault(c => c.PlayerId == id);

                var iBaseEntity = (PlayerItem)entity; // приводим тип к нужному

                // Если сущность найдена, то обновляем ее значения
                if (playerEntity != null)
                {
                    playerEntity.Name = iBaseEntity.Name;
                    playerEntity.Surname = iBaseEntity.Surname;
                    playerEntity.Number = iBaseEntity.Number;
                    playerEntity.VsporteDescription = iBaseEntity.VsporteDescription;

                    // Сохраняем изменения в базу данных
                    await _context.SaveChangesAsync();
                }
            }
        }

        async Task IBaseCrudStrategy.DeleteEntity(int id) // обновление сущности клуба в БД
        {
            using (_context)
            {
                var playerEntity = _context.PlayerItems.FirstOrDefault(c => c.PlayerId == id);

                // Если сущность найдена, то удаляем ее
                if (playerEntity != null)
                {
                    _context.Remove(playerEntity);

                    // Сохраняем изменения в базу данных
                    await _context.SaveChangesAsync();
                }
            }
        }

        #endregion

    }
}

