namespace Business.Dtos.Requests.Admin;

public class UpdateAdminRequest
{
    public Guid Id { get; set; }
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
    public Guid? RoleId { get; set; }
}