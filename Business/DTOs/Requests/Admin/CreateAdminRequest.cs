namespace Business.Dtos.Requests.Admin;

public class CreateAdminRequest
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}