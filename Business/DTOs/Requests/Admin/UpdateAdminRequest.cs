namespace Business.Dtos.Requests.Admin;

public class UpdateAdminRequest
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
}