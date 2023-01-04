using System;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ck.Server.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext // AQUI NAO ESTA REFERENCIANDO
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Person> Person { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<Plan> Plan { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}