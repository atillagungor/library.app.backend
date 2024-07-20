using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concretes;

public class User : Entity<Guid>
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public Guid RoleId { get; set; }

    [Required]
    public Role Role { get; set; }
}