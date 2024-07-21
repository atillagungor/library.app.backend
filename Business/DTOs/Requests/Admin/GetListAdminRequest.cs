namespace Business.Dtos.Requests.Admin;

public class GetListAdminRequest
{
    public Guid? Id { get; set; }
    public string? Email { get; set; }
}