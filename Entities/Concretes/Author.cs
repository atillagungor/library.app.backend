using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concretes;

public class Author: Entity<Guid>
{
    [Required]
    public string Name { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();
}