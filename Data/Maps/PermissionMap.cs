using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps
{
    public class PermissionMap : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("permissao");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id_permissao")
                .UseIdentityColumn();

            builder.Property(p => p.VisualName)
                .HasColumnName("nome_visual");

            builder.Property(p => p.PermissionName)
                .HasColumnName("nome_permissao");

            builder.HasMany(x => x.UserPermissions)
                .WithOne(p => p.Permission)
                .HasForeignKey(p => p.PermissionId);
        }
    }
}