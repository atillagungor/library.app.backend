using System.ComponentModel.DataAnnotations;

namespace Entities.Concretes;

public class Category:Base
{
    [StringLength(50)]
    [Required]
    public string Name { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();
}