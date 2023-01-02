using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vsporte.HandlerServices.Services.Handlers;
using VSporte.DataAccessLayer.DbContextBase;
using VSporte.DataAccessLayer.Models.Interfaces;
using VSporte.Task.Solution.Models;

namespace Vsporte.HandlerServices.BaseEntityCRUDStrategy.Strategies
{
    /// <summary>
    /// Реализация стратегии CRUD операций для ClubItem
    /// </summary>
    public class ClubItemStrategy : IBaseCrudStrategy
    {
        private readonly DataContext _context = new DataContext(); // контекст базы данных

        Task<IBaseEntity> IBaseCrudStrategy.GetByID(int id) // рисуем красивую ассинхронность для использовании в контроллере
        {
            using (_context)
            { 
                ClubItem? club = _context.ClubItems.ToList().Find(c => c.ClubId == id); // поиск сущности клуба по ее идентификатору
                return Task.FromResult<IBaseEntity>(club);
            }
        }

        async Task IBaseCrudStrategy.AddEntity(IBaseEntity clubItem) // добавление сущности клуба в БД c помощью стратегии
        {
            using (_context)
            { 
               await _context.ClubItems.AddAsync((ClubItem)clubItem);
               await _context.SaveChangesAsync();
            }
        }

        async Task IBaseCrudStrategy.UpdateEntity(int id, IBaseEntity entity) // обновление сущности клуба в БД
        {
            using (_context)
            {
                var clubEntity = _context.ClubItems.FirstOrDefault(c => c.ClubId == id);

                var iBaseEntity = (ClubItem)entity; // приводим тип к нужному

                // Если сущность найдена, то обновляем ее значения
                if (clubEntity != null)
                {
                    clubEntity.FullName = iBaseEntity.FullName;
                    clubEntity.City = iBaseEntity.City;
                    clubEntity.VsporteDescription = iBaseEntity.VsporteDescription;

                    // Сохраняем изменения в базу данных
                    await _context.SaveChangesAsync();
                }
            }
        }

        async Task IBaseCrudStrategy.DeleteEntity(int id) // обновление сущности клуба в БД
        {
            using (_context)
            {
                var clubEntity = _context.ClubItems.FirstOrDefault(c => c.ClubId == id);

                // Если сущность найдена, то удаляем ее
                if (clubEntity != null)
                {
                    _context.Remove(clubEntity);

                    // Сохраняем изменения в базу данных
                   await _context.SaveChangesAsync();
                }
            }
        }

    }
}
