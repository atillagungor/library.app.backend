namespace Business.Dtos.Requests.Book;

public class CreateBookRequest
{
    public string? Name { get; set; }
    public int Page { get; set; }
    public string? ImageUrl { get; set; }
    public string? Summary { get; set; }
    public Guid AuthorId { get; set; }
    public Guid CategoryId { get; set; }
}