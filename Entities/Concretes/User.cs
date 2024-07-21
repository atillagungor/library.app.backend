using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concretes;

public class User : Entity<Guid>,IUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public ICollection<UserOperationClaim> Claims { get; set; }
    public ICollection<ForgotPassword> ForgotPasswords { get; set; }
}