namespace Business.Dtos.Requests.Admin;

public class GetListAdminRequest
{
    public Guid? Id { get; set; }
    public string? Username { get; set; }
    public Guid? RoleId { get; set; }
}