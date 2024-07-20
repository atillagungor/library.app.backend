using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concretes;

public class Role : Entity<Guid>
{
    [Required]
    public string Name { get; set; }
}