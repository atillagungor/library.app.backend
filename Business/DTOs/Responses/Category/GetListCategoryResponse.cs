namespace Business.Dtos.Responses.Category;

public class GetListCategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Guid> BookIds { get; set; } = new List<Guid>();
}