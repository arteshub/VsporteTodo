using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VSporte.DataAccessLayer.DbContextBase;
using VSporte.DataAccessLayer.Models.Interfaces;
using VSporte.Task.Solution.Models;
using VSporte.Task.Test.Providers;

namespace VSporte.Tasks.Test.Providers;

public class FingerprintProviderTask_1_1 : BaseFingerPrintProvider
{

    /// <summary>
    /// Отправить модель для манипуляций с бд для сравнения
    /// </summary>
    /// <returns></returns>
    public override void AddModelToDataBase()
    {
        DataContext _context = new DataContext(); // контекст базы данных
        using (_context)
        {
            List<ClubItem> clubItems = new List<ClubItem>
        {
            new ClubItem{ FullName = "Родина", City = "Москва" },
            new ClubItem{ FullName = "Родина", City = "Москва" },
            new ClubItem{ FullName = "Спартак" },
        };
            List<PlayerItem> playerItems = new List<PlayerItem>
        {
            new PlayerItem{ Surname = "Пупкин    ", Name = "Игорь", Number = "25" },
            new PlayerItem{ Surname = "  Сидоров", Name = "Федор", Number = "13" },
            new PlayerItem{ Surname = "пупкин", Name = "Игорь", Number = "25" },
            new PlayerItem{ Surname = "Сидоров", Name = "Федор", Number = "13" },
            new PlayerItem{ Surname = "Двинятин", Name = "Николай", Number = "90" },
            new PlayerItem{ Surname = "   пупкин     ", Name = "Игорь", Number = "25" },
            new PlayerItem{ Surname = "Котов", Name = "Николай", Number = "2" },
        };
            List<PlayerClubItem> playerClubItems = new List<PlayerClubItem>
        {
            new PlayerClubItem{ ClubId = 1, PlayerId = 1 },
            new PlayerClubItem{ ClubId = 1, PlayerId = 2 },
            new PlayerClubItem{ ClubId = 1, PlayerId = 3 },
            new PlayerClubItem{ ClubId = 2, PlayerId = 4 },
            new PlayerClubItem{ ClubId = 2, PlayerId = 5 },
            new PlayerClubItem{ ClubId = 3, PlayerId = 6 },
            new PlayerClubItem{ ClubId = 3, PlayerId = 7 },
        };

            _context.AddRange(clubItems);
            _context.AddRange(playerItems);
            _context.AddRange(playerClubItems);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Получить эталонную модель
    /// </summary>
    /// <returns></returns>
    public override (List<ClubItem>, List<PlayerItem>, List<PlayerClubItem>) GetEtalonModel()
    {
        List<ClubItem> etalonClubItems = new List<ClubItem>
        {
            new ClubItem{ ClubId = 1, FullName = "Родина", City = "Москва", VsporteDescription = null },
            new ClubItem{ ClubId = 3, FullName = "Спартак" , City = null, VsporteDescription = null },
        };
        List<PlayerItem> etalonPlayerItems = new List<PlayerItem>
        {
            new PlayerItem{PlayerId = 1, Surname = "Пупкин", Name = "Игорь", Number = "25", VsporteDescription = null },
            new PlayerItem{PlayerId = 2, Surname = "Сидоров", Name = "Федор", Number = "13", VsporteDescription = null },
            new PlayerItem{PlayerId = 5, Surname = "Двинятин", Name = "Николай", Number = "90", VsporteDescription = null },
            new PlayerItem{PlayerId = 7, Surname = "Котов", Name = "Николай", Number = "2", VsporteDescription = null },
        };
        List<PlayerClubItem> etalonPlayerClubItems = new List<PlayerClubItem>
        {
            new PlayerClubItem{ SystemId = 1, PlayerId = 1, ClubId = 1 },
            new PlayerClubItem{ SystemId = 2, PlayerId = 2, ClubId = 1 },
            new PlayerClubItem{ SystemId = 3, PlayerId = 3, ClubId = 1 },
            new PlayerClubItem{ SystemId = 4, PlayerId = 4, ClubId = 2 },
            new PlayerClubItem{ SystemId = 5, PlayerId = 5, ClubId = 2 },
            new PlayerClubItem{ SystemId = 6, PlayerId = 6, ClubId = 3 },
            new PlayerClubItem{ SystemId = 7, PlayerId = 7, ClubId = 3 },
        };

        return (etalonClubItems, etalonPlayerItems, etalonPlayerClubItems);
    }
}
