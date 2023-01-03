using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSporte.DataAccessLayer.Models;
using VSporte.Task.Solution.Models;

namespace VSporte.DataAccessLayer.DbContextBase
{
    /// <summary>
    /// Класс, описывающий основной контекст
    /// для связи EntityFramework с базой данных
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext() { }

        // описание сущности клубов 
        public DbSet<ClubItem> ClubItems { get; set; }

        // описание сущности связи клубов и игроков
        public DbSet<PlayerClubItem> PlayerClubItems { get; set; }

        // описание сущности игроков
        public DbSet<PlayerItem> PlayerItems { get; set; }

        // описание сущности игровых событий
        public DbSet<GameEvent> GameEvents { get; set; }

        // инициализация строки подключения
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDb;database=VsporteDB03012023;trusted_connection=true");
        }
    }
}
