using System;
using System.Threading.Tasks;
using Ck.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ck.Server.Infra.Data.Context
{
  public class ApplicationDbContext : DbContext // AQUI NAO ESTA REFERENCIANDO
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<Person> People { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
  }
}