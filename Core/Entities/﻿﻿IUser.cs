namespace Core.Entities;
public interface IUser
{
    public Guid Id { get; set; }
    string UserName { get; set; }
    string Email { get; set; }
    byte[] PasswordSalt { get; set; }
    byte[] PasswordHash { get; set; }
}