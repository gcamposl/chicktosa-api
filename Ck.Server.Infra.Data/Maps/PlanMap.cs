using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ck.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ck.Server.Infra.Data.Maps
{
  public class PlanMap : IEntityTypeConfiguration<Plan>
  {
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
      builder.ToTable("plano");
      builder.HasKey(p => p.Id);

      builder.Property(p => p.Id)
        .HasColumnName("id_plano")
        .UseIdentityColumn();

      builder.Property(p => p.PersonId)
        .HasColumnName("id_pessoa");

      builder.Property(p => p.PetId)
        .HasColumnName("id_pet");

      builder.Property(p => p.Maturity)
        .HasColumnName("data_vencimento");

      builder.Property(p => p.Price)
        .HasColumnName("preco");

      builder.HasOne(p => p.Person)
        .WithMany(p => p.Plan);

      builder.HasOne(p => p.Pet)
        .WithMany(p => p.Plan);
    }
  }
}