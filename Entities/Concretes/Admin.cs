using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concretes;

public class Admin : Entity<Guid>
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    [Required]
    public Guid RoleId { get; set; }

    [Required]
    public Role Role { get; set; }
}