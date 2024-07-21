namespace Business.Dtos.Requests.User;

public class CreateUserRequest
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public Guid RoleId { get; set; }
}