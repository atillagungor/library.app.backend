namespace Business.Dtos.Responses.Admin;

public class UpdatedAdminResponse
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public Guid RoleId { get; set; }
}