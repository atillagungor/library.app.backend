using System.ComponentModel.DataAnnotations;

namespace Entities.Concretes;

public class Book:Base
{
    [Required]
    public string Name { get; set; }
    public int Page { get; set; }
    public string ImageUrl { get; set; }
    public string Summary { get; set; }

    public Guid AuthorId { get; set; }

    public Author Author { get; set; }
}