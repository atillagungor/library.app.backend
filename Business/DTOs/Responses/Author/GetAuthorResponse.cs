namespace Business.Dtos.Responses.Author;

public class GetAuthorResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public List<Guid> BookIds { get; set; } = new List<Guid>();
}