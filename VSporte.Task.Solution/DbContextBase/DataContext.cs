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
    public class DataContext : DbContext
    {
        public DataContext () 
        {

        }
        public DbSet<ClubItem> ClubItems { get; set; }
        public DbSet<PlayerClubItem> PlayerClubItems { get; set; }
        public DbSet<PlayerItem> PlayerItems { get; set; }
        public DbSet<GameEvent> GameEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDb;database=VsporteDB02012023;trusted_connection=true");
        }
    }
}
