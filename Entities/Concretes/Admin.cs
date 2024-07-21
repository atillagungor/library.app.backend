using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concretes;

public class Admin : Entity<Guid>
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string PasswordHash { get; set; }
}