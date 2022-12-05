using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Ck.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ck.Server.Infra.Data.Maps
{
  public class PetMap : IEntityTypeConfiguration<Pet>
  {
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
      builder.ToTable("pet");
      builder.HasKey(p => p.Id);

      builder.Property(p => p.Id)
        .HasColumnName("id_pet")
        .UseIdentityColumn();

      builder.Property(p => p.Name)
        .HasColumnName("nome");

      builder.Property(p => p.Race)
        .HasColumnName("raca");

      builder.Property(p => p.Weight)
        .HasColumnName("peso");

      builder.HasMany(p => p.Plan)
        .WithOne(x => x.Pet)
        .HasForeignKey(p => p.PetId);
    }
  }
}