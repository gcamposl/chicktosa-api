using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps
{
    public class PersonImageMap : IEntityTypeConfiguration<PersonImage>
    {
        public void Configure(EntityTypeBuilder<PersonImage> builder)
        {
            builder.ToTable("pessoa_imagem");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id_imagem")
                .UseIdentityColumn();

            builder.Property(x => x.PersonId)
                .HasColumnName("id_pessoa");

            builder.Property(x => x.ImageBase)
                .HasColumnName("imagem_base");

            builder.Property(x => x.ImageUri)
                .HasColumnName("imagem_url");

            builder.HasOne(x => x.Person)
                .WithMany(x => x.PersonImages);
        }
    }
}