using System.ComponentModel.DataAnnotations;

namespace Entities.Concretes;

public class Role:Base
{
    [Required]
    public string Name { get; set; }
}