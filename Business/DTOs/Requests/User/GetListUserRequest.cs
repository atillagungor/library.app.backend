namespace Business.Dtos.Requests.User;

public class GetListUserRequest
{
    public Guid? Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public Guid? RoleId { get; set; }
}