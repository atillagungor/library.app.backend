namespace Business.Dtos.Requests.Admin;

public class CreateAdminRequest
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public Guid RoleId { get; set; }
}