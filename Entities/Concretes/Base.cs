using System.ComponentModel.DataAnnotations;

namespace Entities.Concretes;

public class Base
{
    [Required]
    public Guid Id { get; set; }
}