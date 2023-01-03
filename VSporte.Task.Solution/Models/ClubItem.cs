using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VSporte.DataAccessLayer.Models;
using VSporte.DataAccessLayer.Models.Interfaces;

namespace VSporte.Task.Solution.Models;

    /// <summary>
    /// ������, ����������� �������� �����
    /// </summary>
    public class ClubItem: IBaseEntity
    {
        [Key]
        public int ClubId { get; set; } // ������������� �����
        public string FullName { get; set; } = string.Empty; // ������ ��������
        public string? City { get; set; } = string.Empty; // ����� �����
        public string? VsporteDescription { get; set; } = string.Empty; // ���������� Vsporte
        public string? ShortName { get; set; } = string.Empty; // ������� ����������

        // �������� ��� ��������� ������� ������
        public virtual ICollection<GameEvent> GameEvents { get; set; }
        public virtual ICollection<PlayerClubItem> PlayerClubItems { get; set; }
    }