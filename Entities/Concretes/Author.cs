using System.ComponentModel.DataAnnotations;

namespace Entities.Concretes;

public class Author: Base
{
    [Required]
    public string Name { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();
}