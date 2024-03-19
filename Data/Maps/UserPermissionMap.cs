using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps
{
    public class UserPermissionMap : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.ToTable("permissao_usuario");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id_permissao_usuario")
                .UseIdentityColumn();
            builder.Property(p => p.UserId)
                .HasColumnName("id_usuario");
            builder.Property(p => p.PermissionId)
                .HasColumnName("id_permissao");

            builder.HasOne(x => x.Permission)
                .WithMany(x => x.UserPermissions);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserPermissions);
        }
    }
}