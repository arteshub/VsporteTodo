using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VSporte.DataAccessLayer.Models;
using VSporte.DataAccessLayer.Models.Interfaces;

namespace VSporte.Task.Solution.Models;

/// <summary>
/// ������, ����������� �������� ������
/// </summary>
public class PlayerItem : IBaseEntity
{
    [Key]
    public int PlayerId { get; set; } // ������������� ������
    public string Surname { get; set; } = string.Empty; // �������� ������
    public string Name { get; set; } = string.Empty; // ��� ������
    public string Number { get; set; } = string.Empty; // ����� ������
    public string? VsporteDescription { get; set; } = string.Empty; // ����������� �������

    // �������� ��� ��������� ������� ������
    public virtual ICollection<GameEvent> GameEvents { get; set; }
    public virtual ICollection<PlayerClubItem> PlayerClubItems { get; set; }
}