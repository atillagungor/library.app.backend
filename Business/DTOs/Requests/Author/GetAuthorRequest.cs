namespace Business.Dtos.Requests.Author;

public class GetAuthorRequest
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}