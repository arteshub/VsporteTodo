using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSporte.DataAccessLayer.DbContextBase;
using VSporte.Task.Solution.Models;

namespace VSporte.Task.Test.Providers
{
    /// <summary>
    /// Класс для определения базовых тестовых методов
    /// </summary>
    public abstract class BaseFingerPrintProvider
    {
        /// <summary>
        /// Дропаем все модельки
        /// </summary>
        /// <returns></returns>
        public void TruncateModelFromDatabase()
        {
            DataContext _context = new DataContext(); // контекст базы данных
            using (_context)
            {
                string sql = "TRUNCATE TABLE dbo.ClubItems; TRUNCATE TABLE dbo.PlayerItems; TRUNCATE TABLE dbo.PlayerClubItems;";
                _context.Database.ExecuteSqlRaw(sql);
            }
        }

        /// <summary>
        /// Получить модель для сравнения
        /// </summary>
        /// <returns></returns>
        public (List<ClubItem>, List<PlayerItem>, List<PlayerClubItem>) GetModelFromDatabase()
        {
            DataContext _context = new DataContext(); // контекст базы данных
            using (_context)
            {
                var clubItems = _context.ClubItems.ToList();
                var playerItems = _context.PlayerItems.ToList();
                var playerClubItems = _context.PlayerClubItems.ToList();

                return (clubItems, playerItems, playerClubItems);
            }
        }

        /// <summary>
        /// Добавить модель в базу
        /// </summary>
        public abstract void AddModelToDataBase();

        /// <summary>
        /// Получить эталонную модель
        /// </summary>
        /// <returns>Эталонная модель</returns>
        public abstract (List<ClubItem>, List<PlayerItem>, List<PlayerClubItem>) GetEtalonModel();
    }

}
