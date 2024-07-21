using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(u => u.Email).HasColumnName("Email").IsRequired();

        builder.HasIndex(u => u.Email, "UK_Users_Email").IsUnique();

        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);
        builder.HasMany(u => u.Claims).WithOne(uc => uc.User).HasForeignKey(uc => uc.UserId);
        builder.HasMany(u => u.ForgotPasswords).WithOne(fp => fp.User).HasForeignKey(fp => fp.UserId);
    }
}