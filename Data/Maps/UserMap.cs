using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("usuario");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("id_usuario");

            builder.Property(u => u.Email)
                .HasColumnName("email");

            builder.Property(u => u.Password)
                .HasColumnName("senha");

            builder.HasMany(x => x.UserPermissions)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}