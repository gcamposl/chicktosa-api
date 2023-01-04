using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ck.Server.Infra.Data.Maps
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("pessoa");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
              .HasColumnName("id_pessoa")
              .UseIdentityColumn();

            builder.Property(c => c.Name)
              .HasColumnName("nome");

            builder.Property(c => c.Document)
              .HasColumnName("documento");

            builder.Property(c => c.Phone)
              .HasColumnName("telefone");

            builder.HasMany(c => c.Plan)
              .WithOne(p => p.Person)
              .HasForeignKey(c => c.PersonId);
        }
    }
}