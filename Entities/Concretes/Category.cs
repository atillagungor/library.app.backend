using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concretes;

public class Category : Entity<Guid>
{
    [StringLength(50)]
    [Required]
    public string Name { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();
}