namespace Business.Dtos.Requests.Author;

public class UpdateAuthorRequest
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}