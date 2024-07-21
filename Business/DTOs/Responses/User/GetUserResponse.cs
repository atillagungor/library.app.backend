namespace Business.Dtos.Responses.User;

public class GetUserResponse
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public Guid RoleId { get; set; }
    public string RoleName { get; set; }
}