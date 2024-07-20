using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Username)
            .IsRequired()
            .HasColumnName("Username");

        builder.Property(u => u.PasswordHash)
            .IsRequired()
            .HasColumnName("PasswordHash");

        builder.Property(u => u.Email)
            .IsRequired()
            .HasColumnName("Email");

        builder.Property(u => u.RoleId)
            .IsRequired()
            .HasColumnName("RoleId");

        builder.HasOne(u => u.Role)
            .WithMany()
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}