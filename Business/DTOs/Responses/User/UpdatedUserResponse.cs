namespace Business.Dtos.Responses.User;

public class UpdatedUserResponse
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public Guid RoleId { get; set; }
}