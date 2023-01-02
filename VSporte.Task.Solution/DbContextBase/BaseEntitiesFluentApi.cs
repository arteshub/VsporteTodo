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
    internal class BaseEntitiesFluentApt : DbContext
    {
        /// <summary>
        /// метод описывающий связи в БД и вешающий нужные ключики
        /// </summary>
        /// <param name = "modelBuilder" ></ param >
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Первичный ключ для сущности PlayerItem 
            modelBuilder.Entity<PlayerItem>()
                .HasKey(p => p.PlayerId);

            // Первичный ключ для сущности PlayerItem 
            modelBuilder.Entity<ClubItem>()
                .HasKey(c => c.ClubId);

            // указываем, что у сущности PlayerClubItem есть составной первичный ключ, состоящий из полей PlayerId и ClubId
            modelBuilder.Entity<PlayerClubItem>()
                .HasKey(pc => new { pc.PlayerId, pc.ClubId });

            modelBuilder.Entity<PlayerClubItem>()
                .HasOne(pc => pc.Club)
                .WithMany(c => c.PlayerClubItems)
                .HasForeignKey(pc => pc.ClubId);

            modelBuilder.Entity<PlayerClubItem>()
            .HasOne(pc => pc.Player)
            .WithMany(p => p.PlayerClubItems)
            .HasForeignKey(pc => pc.PlayerId);

            modelBuilder.Entity<GameEvent>()
                .HasOne(g => g.Club)
                .WithMany(c => c.GameEvents)
                .HasForeignKey(g => g.ClubId);

            modelBuilder.Entity<GameEvent>()
                .HasOne(g => g.Player)
                .WithMany(p => p.GameEvents)
                .HasForeignKey(g => g.PlayerId);
        }
    }
}
