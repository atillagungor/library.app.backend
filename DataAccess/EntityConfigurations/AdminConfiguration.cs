using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admins");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Email)
                .IsRequired()
                .HasColumnName("Email");

            builder.Property(a => a.PasswordHash)
                .IsRequired()
                .HasColumnName("PasswordHash");
        }
    }
}
