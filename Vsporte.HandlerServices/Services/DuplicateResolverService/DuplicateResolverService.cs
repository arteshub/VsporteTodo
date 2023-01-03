using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Vsporte.HandlerServices.BaseEntityCRUDStrategy;
using Vsporte.HandlerServices.Services.Handlers;
using VSporte.DataAccessLayer.DbContextBase;
using VSporte.Task.Solution.Models;

namespace Vsporte.HandlerServices.Services.DuplicateResolverService
{
    public static class DuplicateResolverService
    {
        private static readonly DataContext _context = new DataContext(); // контекст базы данных
        public async static Task DuplicateResolveBad()
        {
            // фикс дублирующихся записей Задание 1.1
            using (_context)
            {
                var clubsToRemove = _context.ClubItems
                   .AsEnumerable()
                   .GroupBy(r => new
                   {
                       ValidizeFullName = r.FullName.NormalizeName(),
                       ValidizeCity = r.City.NormalizeName(),
                   })
                   .Where(g => g.Count() > 1)
                   .SelectMany(g => g.Skip(1)).ToList(); // делаем выборку дубликатов, оставляя первый

                _context.ClubItems.RemoveRange(clubsToRemove);

                // Сохраняем изменения
                await _context.SaveChangesAsync();

                var itemsToRemove = _context.PlayerItems
                    .AsEnumerable()
                    .GroupBy(r => new
                    {
                        ValidizeSurname = r.Surname.NormalizeName(),
                        ValidizeName = r.Name.NormalizeName(),
                        ValidizeNumber = r.Number
                    })
                .Where(g => g.Count() > 1)
                    .SelectMany(g => g.Skip(1)).ToList();

                _context.PlayerItems.RemoveRange(itemsToRemove);

                // Сохраняем изменения
                await _context.SaveChangesAsync();
            }
        }

        // фикс дублирующихся записей Задание 1.2
        public static async Task DuplicateResolveGood()
        {
            // так как логика довольно сложная - выношу ее на сторону БД
            // хранимые процедуры хранятся в папке "StoredProcedures" в корне решения
            using(_context)
            {
                await _context.Database.ExecuteSqlRawAsync("EXEC dbo.DuplicatesKillerTask1_2");
            }
            
        }

        public async static Task DuplicateResolvePerfect()
        {
            // фикс дублирующихся записей Задание 1.3
            // так как логика довольно сложная - выношу ее на сторону БД
            // хранимые процедуры хранятся в папке "StoredProcedures" в корне решения
            using (_context)
            {
                await _context.Database.ExecuteSqlRawAsync("EXEC dbo.DuplicatesKillerTask1_3");
            }
        }
    }
}
